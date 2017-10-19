using System;
using System.Collections.Generic;
using System.IO;
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
            File.AppendAllLines("C:\\Users\\ivano.scifoni\\Desktop\\ShoppingCartEvent.log", new List<string>() { $"{DateTime.Now.ToLongDateString()} - Modificato ID Prodotto {@event.ProductId} Con il nuovo prezzo {@event.NewPrice}\n\r" });
            return Task.CompletedTask;
        }
    }
}
