using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingOnLine.EventBus.Abstraction;
using ShoppingOnLine.Marketing.Api.Model;
using ShoppingOnLine.ShoppingCart.Api.Event;

namespace ShoppingOnLine.Marketing.Api.Repository
{
    public class MarketingApiRepository
    {
        IEventBus _eventBus;

        public MarketingApiRepository(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        public void UpdatePrice(UpdatePrice model)
        {
            //do update of DB

            //Release event ShoppingCartUpdateEvent
            var @event = new ShoppingCartChangePriceIntegrationEvent(model.ProductId, model.NewPrice );
            _eventBus.Publish(@event);
        }
    }
}
