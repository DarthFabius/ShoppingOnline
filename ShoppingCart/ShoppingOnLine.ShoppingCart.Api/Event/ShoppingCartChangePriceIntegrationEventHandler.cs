using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShoppingOnLine.EventBus.Abstraction;

namespace ShoppingOnLine.ShoppingCart.Api.Event
{
    public class ShoppingCartChangePriceIntegrationEventHandler : 
        IIntegrationEventHandler<ShoppingCartChangePriceIntegrationEvent>
    {
        
        public Task Handle(ShoppingCartChangePriceIntegrationEvent @event)
        {

            return Task.CompletedTask;
        }
    }
}
