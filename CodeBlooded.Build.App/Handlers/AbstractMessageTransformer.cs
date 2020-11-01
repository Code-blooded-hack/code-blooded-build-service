using System;
using System.Text.Json;
using Transport;


namespace CodeBlooded.Build.App.Handlers
{
    public abstract class AbstractMessageTransformer<TInputMessage, TOutputMessage>
        where TInputMessage : class
        where TOutputMessage : class
    {
        private readonly IInputQueue _inputQueue;
        private readonly IOutputQueue _outputQueue;
        

        protected AbstractMessageTransformer(IInputQueue inputQueue, IOutputQueue outputQueue)
        {
            _inputQueue = inputQueue ?? throw new ArgumentNullException(nameof(inputQueue));
            _outputQueue = outputQueue ?? throw new ArgumentNullException(nameof(outputQueue));
        }


        protected abstract Message<TOutputMessage> TransformMessage(TInputMessage message, string routeKey);

        
        private (MessageAction action, bool requeuee) OnMessage(IInputQueue sender, string routingKey, string body)
        {
            try
            {
                var message = JsonSerializer.Deserialize<TInputMessage>(body);

                if (message == null)
                    return (MessageAction.Reject, false);

                var outputMessage = TransformMessage(message, routingKey);

                if (outputMessage.Value == null)
                    return (MessageAction.Ack, false);
                
                _outputQueue.Send(outputMessage.Value, outputMessage.RoutingKey ?? "");
                
                return (MessageAction.Ack, false);
            }
            catch (Exception x)
            {
                if (x is ArgumentNullException || x is JsonException)
                    return (MessageAction.Reject, false);

                return (MessageAction.None, true);
            }
        }

        public void Dispose() => _inputQueue.Received -= OnMessage;
    }
}