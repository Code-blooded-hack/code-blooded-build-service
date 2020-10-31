using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using EasyNetQ;
using EasyNetQ.AutoSubscribe;


namespace CodeBlooded.Build.Consumers
{
    public abstract class AbstractQueueProcessor<TInputMessage, TOutputMessage> : IConsumeAsync<TInputMessage> 
        where TInputMessage : class
        where TOutputMessage : class
    {
        private readonly IBus _bus;
        private readonly ILogger _logger;
        

        public AbstractQueueProcessor(IBus bus, ILoggerFactory loggerFactory)
        {
            _bus = bus;
            _logger = loggerFactory.CreateLogger(GetType());
        }


        protected abstract Task<TOutputMessage> HandleMessage(TInputMessage target, IBus bus, ILogger logger);
        
        
        public async Task ConsumeAsync(TInputMessage target)
        {
            var produced = await HandleMessage(target, _bus, _logger);
            await _bus.PublishAsync(produced);
        }
    }
}