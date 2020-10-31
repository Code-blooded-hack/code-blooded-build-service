using Transport;
using CodeBlooded.Build.App.Messages;
using CodeBlooded.Build.Messages;


namespace CodeBlooded.Build.App.Handlers
{
    public class ExecuteResponseHandler : AbstractMessageTransformer<ExecuteResponse, CheckResponse>
    {
        public ExecuteResponseHandler(IInputQueue inputQueue, IOutputQueue outputQueue) 
            : base(inputQueue, outputQueue) { }

        
        protected override Message<CheckResponse> TransformMessage(ExecuteResponse message)
        {
            var response = new CheckResponse
            {

            };
            
            return new Message<CheckResponse>(response, "");
        }
    }
}