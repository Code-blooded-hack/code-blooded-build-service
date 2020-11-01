using System;
using CodeBlooded.Build.App.Handlers;
using CodeBlooded.Build.App.Messages;
using Microsoft.Extensions.Configuration;
using Transport.Config;
using Transport.Impl;
using Transport.Queues;

namespace CodeBlooded.Build.App
{
    public static class Program
    {
        private static Application App;
        
        public static int Main(string[] args)
        {
            try
            {
                App = ConfigureApplication();
        
                Console.WriteLine("Application is running, press <ENTER> to stop it.");
                Console.ReadLine();
        
                return 0;
            }
            catch (Exception x)
            {
                Console.WriteLine(x.ToString());
                return -1;   
            }
        }
        
        private static QueueConfig GetQueueConfiguration(IConfiguration configuration, string key)
            => configuration
                .GetSection("RabbitMqConfig")
                .GetSection("Queues")
                .GetSection(key)
                .Get<QueueConfig>();

        private static ConnectionConfig GetConnectionConfig(IConfiguration configuration)
            => configuration
                .GetSection("RabbitMqConfig")
                .GetSection("Connection")
                .Get<ConnectionConfig>();
        
        // Прочитай этот метод и осознай, как тебе было плохо без DI-контейнеров...
        private static Application ConfigureApplication()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionConfig = GetConnectionConfig(configuration);
            var executeRequestQueueConfig = GetQueueConfiguration(configuration, nameof(ExecuteRequest));
            var executeResponseQueueConfig = GetQueueConfiguration(configuration, nameof(ExecuteResponse));
            var checkRequestQueueConfig = GetQueueConfiguration(configuration, nameof(CheckRequest));
            var checkResponseQueueConfig = GetQueueConfiguration(configuration, nameof(CheckResponse));
            var codeHealthRequestQueueConfig = GetQueueConfiguration(configuration, nameof(CodeHealthRequest));
            var codeHealthResponseQueueConfig = GetQueueConfiguration(configuration, "CodeHealthResponse");
            
            var factory = new DefaultRabbitMqConnectionFactory();

            var connection = factory.Connect(connectionConfig);
            var executeRequestQueue = new OutputQueue();
            var executeResponseQueue = new InputQueue();
            var checkRequestQueue = new InputQueue();
            var checkResponseQueue = new OutputQueue();
            var codeHealthRequestQueue = new InputQueue();
            var codeHealthResponseQueue = new OutputQueue();
            
            var checkRequestHandler = new CheckRequestHandler(checkRequestQueue, executeRequestQueue);
            var codeHealthHandler = new CodeHealthRequestHandler(codeHealthRequestQueue, executeRequestQueue);
            var executeResponseHandler = new ExecuteResponseHandler(executeResponseQueue, checkResponseQueue, codeHealthResponseQueue);
            
            executeRequestQueue.Init(connection, executeRequestQueueConfig);
            executeResponseQueue.Init(connection, executeResponseQueueConfig);
            checkRequestQueue.Init(connection, checkRequestQueueConfig);
            checkResponseQueue.Init(connection, checkResponseQueueConfig);
            codeHealthRequestQueue.Init(connection, codeHealthRequestQueueConfig);
            codeHealthResponseQueue.Init(connection, codeHealthResponseQueueConfig);
            
            return new Application(checkRequestHandler, executeResponseHandler, codeHealthHandler);
        }
    }
}