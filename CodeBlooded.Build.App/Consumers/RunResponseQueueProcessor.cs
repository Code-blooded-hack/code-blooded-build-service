using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using EasyNetQ;

using CodeBlooded.Build.Consumers;
using CodeBlooded.Build.Messages;


namespace CodeBlooded.Build.App.Consumers
{
    public class RunResponseQueueProcessor : AbstractQueueProcessor<RunResponseMessage, CheckResponseMessage>
    {
        public RunResponseQueueProcessor(IBus bus, ILoggerFactory loggerFactory) : base(bus, loggerFactory) { }


        protected override Task<CheckResponseMessage> HandleMessage(RunResponseMessage target, IBus bus, ILogger logger)
            => Task.FromResult(new CheckResponseMessage());
    }
}