using System;
using ShoppingOnLine.EventBus.Abstraction;

namespace ShoppingOnLine.Pricing.Api.Event
{
    public class PricingOnPriceChange:IntegrationEvent
    {
        public PricingOnPriceChange(int productId, decimal newPrice)
        {
            ProductId = productId;
            NewPrice = newPrice;
        }
        public int ProductId { get; }

        public decimal NewPrice { get; }
    }
}
