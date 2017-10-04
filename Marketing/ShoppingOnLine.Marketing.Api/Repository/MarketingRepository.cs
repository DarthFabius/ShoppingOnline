using System;
using System.Linq;
using ShoppingOnline.DomainModel;
using ShoppingOnline.DomainModel.Context;
using ShoppingOnLine.EventBus.Abstraction;
using ShoppingOnLine.Marketing.Api.Model;
using ShoppingOnLine.ShoppingCart.Api.Event;

namespace ShoppingOnLine.Marketing.Api.Repository
{
    public class MarketingApiRepository
    {
        IEventBus _eventBus;
        private DbSellingInfoContext _db;

        public MarketingApiRepository(IEventBus eventBus, DbSellingInfoContext db)
        {
            _eventBus = eventBus;
            _db = db;
        }

        public void UpdatePrice(UpdatePrice model)
        {
            //do update of DB 
            var product = _db.SellingoInfos.FirstOrDefault(i => i.ProductId.Equals(model.ProductId));
            product.Amount = model.NewPrice;

            _db.Update(product);
            _db.SaveChanges();
           
            //Release event ShoppingCartUpdateEvent
            var @event = new ShoppingCartChangePriceIntegrationEvent(model.ProductId, model.NewPrice );
            _eventBus.Publish(@event);
        }

        public void InsertPrice(InsertPrice model)
        {
            //do update of DB
            
            var sellingInfo = new SellingInfo
            {
                Amount = model.NewPrice,
                ProductId = model.ProductId,
                Currency = CurrencyType.Sesterzi,
            };

            _db.Add(sellingInfo);
            _db.SaveChanges();
          
            //Release event ShoppingCartUpdateEvent
            var @event = new ShoppingCartNewPriceIntegrationEvent(model.ProductId, model.NewPrice);
            _eventBus.Publish(@event);
        }
    }
}
