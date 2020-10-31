using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using EasyNetQ.AutoSubscribe;


namespace CodeBlooded.Build.App
{
    public class MessageDispatcher : IAutoSubscriberMessageDispatcher
    {
        private readonly IServiceProvider _services;


        public MessageDispatcher(IServiceProvider services) => _services = services;


        public void Dispatch<TMessage, TConsumer>(TMessage message)
            where TMessage : class
            where TConsumer : class, IConsume<TMessage>
            => _services.GetRequiredService<TConsumer>().Consume(message);


        public Task DispatchAsync<TMessage, TConsumer>(TMessage message)
            where TMessage : class
            where TConsumer : class, IConsumeAsync<TMessage>
            => _services.GetRequiredService<TConsumer>().ConsumeAsync(message);
    }
}