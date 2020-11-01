using System;
using Transport;
using CodeBlooded.Build.App.Messages;


namespace CodeBlooded.Build.App.Handlers
{
    public class CheckRequestHandler : AbstractMessageTransformer<CheckRequest, ExecuteRequest>
    {
        public CheckRequestHandler(IInputQueue inputQueue, IOutputQueue outputQueue) : base(inputQueue, outputQueue) { }

        
        protected override Message<ExecuteRequest> TransformMessage(CheckRequest message, string routeKey)
        {
            var routingKey = message.Language;
            
            var request = new ExecuteRequest
            {
                Id = message.Id,
                MemoryLimit =  message.MemoryLimit,
                TimeLimit = TimeSpan.FromMilliseconds(message.TimeLimit),
                Code = message.Code,
                Input = message.Tests
            };

            return new Message<ExecuteRequest>(request, routingKey);
        }
    }
}