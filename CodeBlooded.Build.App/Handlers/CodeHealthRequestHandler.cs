using System;
using System.Linq;
using Transport;
using CodeBlooded.Build.App.Messages;


namespace CodeBlooded.Build.App.Handlers
{
    public class CodeHealthRequestHandler : AbstractMessageTransformer<CodeHealthRequest, ExecuteRequest>
    {
        public CodeHealthRequestHandler(IInputQueue inputQueue, IOutputQueue outputQueue)
            : base(inputQueue, outputQueue) { }


        protected override Message<ExecuteRequest> TransformMessage(CodeHealthRequest message, string routeKey)
        {
            var routingKey = $"{message.Language}.reference";

            var request = new ExecuteRequest
            {
                Id = message.Id,
                MemoryLimit = int.MaxValue,
                TimeLimit = TimeSpan.MaxValue,
                Code = message.Code,
                Input = message.Tests.Select(t => t.Input).ToArray()
            };
            
            return new Message<ExecuteRequest>(request, routingKey);
        }
    }
}