using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingOnLine.EventBus.Abstraction;
using ShoppingOnLine.Pricing.Api.Model;
using ShoppingOnLine.ShoppingCart.Api.Event;

namespace ShoppingOnLine.Pricing.Api.Repository
{
    public class PricingApiRepository
    {
        private IEventBus _eventBus;

        public PricingApiRepository(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        public bool InsertPricing(InsertPrice insertPrice)
        {
            return true;
        }

        public bool UpdatePrice(UpdatePrice updatePrice)
        {
            //Release event ShoppingCartUpdateEvent
            var @event = new ShoppingCartChangePriceIntegrationEvent(updatePrice.ProductId, updatePrice.NewPrice);
            _eventBus.Publish(@event);

            return true;
        }

        public bool DeletePrice(int ProductId)
        {
            return true;
        }

        public IEnumerable<DetailPrice> GetPrice()
        {
            return GetPrice(null);
        }
        public IEnumerable<DetailPrice> GetPrice(IEnumerable<int> ProductIds)
        {
            return null;
        }
        
    }
}
