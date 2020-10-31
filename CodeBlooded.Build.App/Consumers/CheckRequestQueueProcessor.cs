using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using EasyNetQ;

using CodeBlooded.Build.Consumers;
using CodeBlooded.Build.Messages;


namespace CodeBlooded.Build.App.Consumers
{
    public class CheckRequestQueueProcessor : AbstractQueueProcessor<CheckRequestMessage, RunRequestMessage>
    {
        public CheckRequestQueueProcessor(IBus bus, ILoggerFactory loggerFactory) : base(bus, loggerFactory) { }


        protected override Task<RunRequestMessage> HandleMessage(CheckRequestMessage target, IBus bus, ILogger logger)
            => Task.FromResult(new RunRequestMessage());
    }
}