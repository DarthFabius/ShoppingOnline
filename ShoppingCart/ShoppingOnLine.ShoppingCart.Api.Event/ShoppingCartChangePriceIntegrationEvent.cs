using System;
using ShoppingOnLine.EventBus.Abstraction;

namespace ShoppingOnLine.ShoppingCart.Api.Event
{
    public class ShoppingCartChangePriceIntegrationEvent : IntegrationEvent
    {
        public ShoppingCartChangePriceIntegrationEvent(int productId, decimal newPrice)
        {
            ProductId = productId;
            NewPrice = newPrice;
        }

        public int ProductId { get; }

        public decimal NewPrice { get; }
    }

    public class ShoppingCartNewPriceIntegrationEvent : IntegrationEvent
    {
        public ShoppingCartNewPriceIntegrationEvent(int productId, decimal newPrice)
        {
            ProductId = productId;
            NewPrice = newPrice;
        }

        public int ProductId { get; }

        public decimal NewPrice { get; }
    }
}
