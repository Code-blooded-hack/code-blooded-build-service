using System;

using Microsoft.Extensions.Configuration;

using Transport.Config;
using Transport.Impl;

using CodeBlooded.Build.App.Handlers;
using CodeBlooded.Build.App.Messages;


namespace CodeBlooded.Build.App
{
    public class Application : IDisposable
    {
        private readonly CheckRequestHandler _checkRequestHandler;
        private readonly ExecuteResponseHandler _executeResponseHandler;
        private readonly CodeHealthRequestHandler _codeHealthRequestHandler;


        public Application(CheckRequestHandler checkRequestHandler, ExecuteResponseHandler executeResponseHandler,
            CodeHealthRequestHandler codeHealthRequestHandler)
        {
            _checkRequestHandler = checkRequestHandler
                ?? throw new ArgumentNullException(nameof(checkRequestHandler));
            
            _executeResponseHandler = executeResponseHandler
                ?? throw new ArgumentNullException(nameof(checkRequestHandler));
            
            _codeHealthRequestHandler = codeHealthRequestHandler
                ?? throw new ArgumentNullException(nameof(checkRequestHandler));
        }

        
        public void Dispose()
        {
        }
    }
}