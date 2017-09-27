using System;
using System.Collections.Generic;
using System.Text;
using ShoppingOnLine.EventBus.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ShoppingOnLine.EventBus.InMemorySubscription;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ShoppingOnLineInMemoryEventBusSubscriptionManagerServiceBusServiceExtention
    {
        public static IServiceCollection AddInMemorySubscriptionManager(this IServiceCollection services)
        {
            //Discovering batch
            services.TryAddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();

            return services;
        }
    }
}
