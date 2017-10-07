using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShoppingOnLine.EventBus.Abstraction;
using ShoppingOnLine.Pricing.Api.Event;

namespace ShoppingOnLine.ShoppingCart.Api.Event
{
    public class ShoppingCartChangePriceIntegrationEventHandler : 
        IIntegrationEventHandler<PricingOnPriceChange>
    {
        
        public Task Handle(PricingOnPriceChange @event)
        {

            return Task.CompletedTask;
        }
    }
}
