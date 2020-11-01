using System;
using System.Linq;
using Transport;
using CodeBlooded.Build.App.Messages;


namespace CodeBlooded.Build.App.Handlers
{
    public class ExecuteResponseHandler : AbstractMessageTransformer<ExecuteResponse, CheckResponse>
    {
        private readonly IOutputQueue _codeHealthResponseQueue;
        
        public ExecuteResponseHandler(IInputQueue inputQueue, IOutputQueue outputQueue,
            IOutputQueue codeHealthResponseQueue) : base(inputQueue, outputQueue)
        {
            _codeHealthResponseQueue = codeHealthResponseQueue
                ?? throw new ArgumentNullException(nameof(codeHealthResponseQueue));
        }

        
        protected override Message<CheckResponse> TransformMessage(ExecuteResponse message, string routeKey)
        {
            var response = new CheckResponse
            {
                Id = message.Id,
                Results = message.Tests.Select(t => new TestResultResponse
                {
                    Input = t.Input,
                    Output = t.Output,
                    Status = (!string.Equals(t.Input, t.Output, StringComparison.Ordinal)
                           ? "WrongAnswer"
                           : t.Status.ToString()).ToLower()
                }).ToArray()
            };

            if (!routeKey.Equals("reference", StringComparison.OrdinalIgnoreCase))
                return new Message<CheckResponse>(response, null);
            
            _codeHealthResponseQueue.Send(response);
            
            return new Message<CheckResponse>(null, null);
        }
    }
}