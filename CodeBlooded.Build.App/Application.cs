using System;
using System.Linq;
using System.Reflection;
using CodeBlooded.Build.App.Handlers;
using CodeBlooded.Build.App.Messages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Transport;
using Transport.Config;
using Transport.Impl;


namespace CodeBlooded.Build.App
{
    public class Application// : IDisposable
    {
        // private readonly MessageConsumer<CheckRequest> _checkRequestConsumer;
        // private readonly MessageConsumer<ExecuteResponse> _executeResponseConsumer;
        //
        //
        // public Application(MessageConsumer<CheckRequest> checkRequestConsumer, 
        //     MessageConsumer<ExecuteResponse> executeResponseConsumer)
        // {
        //     _checkRequestConsumer = checkRequestConsumer
        //         ?? throw new ArgumentNullException(nameof(checkRequestConsumer));
        //     
        //     _executeResponseConsumer = executeResponseConsumer
        //         ?? throw new ArgumentNullException(nameof(checkRequestConsumer));
        // }
        //
        //
        // public void Dispose()
        // {
        //     _checkRequestConsumer.Dispose();
        //     _executeResponseConsumer.Dispose();
        // }
        //
        //
        // public static int Main(string[] args)
        // {
        //     try
        //     {
        //         var config = Configure();
        //         var services = ConfigureServices(config);
        //
        //         using var app = services.GetRequiredService<Application>();
        //
        //         Console.WriteLine("Application is running, press <ENTER> to stop it.");
        //         Console.ReadLine();
        //
        //         return 0;
        //     }
        //     catch (Exception x)
        //     {
        //         Console.WriteLine(x.ToString());
        //         return -1;   
        //     }
        // }
        
        // private static Application ConfigureApplication()
        // {
            // var rabbitMqConfig = new ConfigurationBuilder()
            //     .AddJsonFile("appsettings.json")
            //     .Build()
            //     .GetSection("RabbitMqConfig");
            //
            // var connectionConfig = rabbitMqConfig
            //     .GetSection("Connection")
            //     .Get<ConnectionConfig>();
            //
            // var checkQueueConfig = rabbitMqConfig
            //     .GetSection("Queues")
            //     .GetSection("Check")
            //     .Get<QueueConfig>();
            //
            // var executeQueueConfig = rabbitMqConfig
            //     .GetSection("Queues")
            //     .GetSection("Execute")
            //     .Get<QueueConfig>();
            //
            //
            // var connection = new DefaultRabbitMqConnectionFactory()
            //     .Connect(connectionConfig);
            //
            // var checkRequestConsumer = new MessageConsumer<CheckRequest>(new CheckRequestHandler(connection, executeQueueConfig), );
            // var executeResponseConsumer = new MessageConsumer<>();
            //
            // return new Application();
    //         throw new NotImplementedException();
    //     }
    }
}