using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingOnLine.EventBus.Abstraction;
using ShoppingOnLine.Pricing.Api.Event;
using ShoppingOnLine.ShoppingCart.Api.Model;

namespace ShoppingOnLine.ShoppingCart.Api.Event
{
    public class ShoppingCartChangePriceIntegrationEventHandler : 
        IIntegrationEventHandler<PricingOnPriceChange>
    {
        Cart _cart;

        public ShoppingCartChangePriceIntegrationEventHandler(Cart cart)
        {
            _cart = cart;
        }

        public Task Handle(PricingOnPriceChange @event)
        {
            if (_cart.Items.Any(p => p.ProductId.Equals(@event.ProductId)))
            { 
                File.AppendAllLines("C:\\Users\\ivano.scifoni\\Desktop\\ShoppingCartEvent.log", 
                    new List<string>() { $"{DateTime.Now.ToLongDateString()} - Modificato ID Prodotto {@event.ProductId} Con il nuovo prezzo {@event.NewPrice}\n\r" });
            }

            return Task.CompletedTask;
        }
    }
}
