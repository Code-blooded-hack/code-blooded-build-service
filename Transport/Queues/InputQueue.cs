namespace Transport.Queues
{
    using System.Text;

    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;

    using Transport.Config;

    /// <summary>
    /// Очередь, в которую отправляются запросы из сторонних систем
    /// </summary>
    public class InputQueue : BaseQueue, IInputQueue
    {
        /// <summary>
        /// Читатель очереди
        /// </summary>
        private EventingBasicConsumer consumer;

        /// <summary>
        /// Событие приема сообщения
        /// </summary>
        public EventGetSourceDataHandler Received { get; set; }

        /// <summary>
        /// Выполняет инициализацию очереди
        /// </summary>
        /// <param name="connection">Соединение, которому принадлежит очередь</param>
        /// <param name="initialConfig">Конфигурация очереди</param>
        public override void Init(IRabbitMqConnection connection, QueueConfig initialConfig)
        {
            base.Init(connection, initialConfig);

            this.DeclareQueue();

            this.consumer = new EventingBasicConsumer(this.Connection.Channel);
            this.consumer.Received += this.RabbitEventHandler;

            lock (this.Connection)
            {
                this.Connection.Channel.BasicConsume(this.InitialConfig.Name, false, this.consumer);
            }
        }

        /// <summary>
        /// Обработчик получение сообщения из RabbitMQ
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="eventArgs">Аргументы события</param>
        protected virtual void RabbitEventHandler(object sender, BasicDeliverEventArgs eventArgs)
        {
            var messageBody = Encoding.UTF8.GetString(eventArgs.Body.ToArray());
            var action = MessageAction.None;
            var requeue = false;
            try
            {
                (action, requeue) = this.Received?.Invoke(this, eventArgs.RoutingKey, messageBody) ?? (this.InitialConfig.DefaultAction, false);
            }
            catch
            {
                action = this.InitialConfig.DefaultAction;
                requeue = false;
                throw;
            }
            finally
            {
                lock (this.Connection)
                {

                    switch (action)
                    {
                        case MessageAction.Reject:
                            this.Connection.Channel.BasicReject(eventArgs.DeliveryTag, requeue);
                            break;
                        case MessageAction.Ack:
                            this.Connection.Channel.BasicAck(eventArgs.DeliveryTag, requeue);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}