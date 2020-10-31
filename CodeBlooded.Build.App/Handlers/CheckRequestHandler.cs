using Transport;
using CodeBlooded.Build.App.Messages;


namespace CodeBlooded.Build.App.Handlers
{
    // TODO: Tutor/Student
    public class CheckRequestHandler : AbstractMessageTransformer<CheckRequest, ExecuteRequest>
    {
        public CheckRequestHandler(IInputQueue inputQueue, IOutputQueue outputQueue) : base(inputQueue, outputQueue) { }

        
        protected override Message<ExecuteRequest> TransformMessage(CheckRequest message)
        {
            var request = new ExecuteRequest
            {
                Id = message.CheckId,
                Code = message.StudentCode,
                Input = message.Input
            };
            
            return new Message<ExecuteRequest>(request, $"{message.Language}.reference");
        }
    }
}