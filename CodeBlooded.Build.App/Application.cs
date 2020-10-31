using System;
using System.Linq;
using System.Reflection;
using CodeBlooded.Build.Messages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using EasyNetQ;
using EasyNetQ.AutoSubscribe;


namespace CodeBlooded.Build.App
{
    public class Application
    {
        public static int Main(string[] args)
        {
            try
            {
                var config = Configure();
                var services = ConfigureServices(config);
                var bus = services.GetRequiredService<IBus>();
                
                var subscriber = new AutoSubscriber(bus, "");

                subscriber.SubscribeAsync(Assembly.GetExecutingAssembly());

                Console.ReadLine();

                Enumerable.Range(0, 10)
                    .ForEach(i =>
                    {
                        bus.PublishAsync(new CheckRequestMessage {StudentCode = new [] {i.ToString()}});
                    });
                
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


        private static IConfiguration Configure()
            => new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

        private static IServiceProvider ConfigureServices(IConfiguration config)
        {
            var services = new ServiceCollection();

            services.AddLogging();
            
            Assembly.GetExecutingAssembly()
                .GetExportedTypes()
                .Where(t => typeof(IConsumeAsync<>).IsAssignableFrom(t))
                .ForEach(t => services.AddSingleton(t));

            services.RegisterEasyNetQ(config.GetConnectionString("RabbitMq"));

            return services.BuildServiceProvider();
        }
    }
}