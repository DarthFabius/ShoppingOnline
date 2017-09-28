using System;
using System.Collections.Generic;
using System.Text;
using ShoppingOnLine.EventBus.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RabbitMQ.Client;
using ShoppingOnLine.EventBus.RabbitMQ;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ShoppingOnLineRabbitMQServiceBusServiceExtention
    {
        public static IServiceCollection AddRabbitMQServiceBus(this IServiceCollection services, string hostName)
        {
            //Discovering batch
            services.TryAddSingleton<IConnectionFactory>(s =>
            {
                return new ConnectionFactory()
                {
                    HostName = hostName
                };
            });
            services.TryAddSingleton<IRabbitMQPersistentConnection, DefaultRabbitMQPersistentConnection>();
            services.TryAddSingleton<IEventBus, EventBusRabbitMQ>();

            return services;
        }
    }
}
