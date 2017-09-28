using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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
        private readonly AppSettings _appSettings;

        public MarketingApiRepository(IOptions<AppSettings> appSettings, IEventBus eventBus)
        {
            _eventBus = eventBus;
            _appSettings = appSettings.Value;
        }
        public void UpdatePrice(UpdatePrice model)
        {
            //do update of DB

            var builderEF = new DbContextOptionsBuilder<DbContextUsers>();
            builderEF.UseSqlServer(_appSettings.ConnectionString);

            using (var db = new DbSellingInfoContext(_appSettings.ConnectionString))
            {
                var product = db.SellingoInfos.FirstOrDefault(i => i.ProductId.Equals(model.ProductId));

                product.Amount = model.NewPrice;

                db.Update(product);

                db.SaveChanges();
            }

            //Release event ShoppingCartUpdateEvent
            var @event = new ShoppingCartChangePriceIntegrationEvent(model.ProductId, model.NewPrice );
            _eventBus.Publish(@event);
        }

        public void InsertPrice(InsertPrice model)
        {
            //do update of DB

            var builderEF = new DbContextOptionsBuilder<DbContextUsers>();
            builderEF.UseSqlServer(_appSettings.ConnectionString);

            using (var db = new DbSellingInfoContext(_appSettings.ConnectionString))
            {
                var sellingInfo = new SellingInfo
                {
                    Amount = model.NewPrice,
                    ProductId = model.ProductId,
                    Currency = CurrencyType.Sesterzi,
                };

                db.Add(sellingInfo);

                db.SaveChanges();
            }

            //Release event ShoppingCartUpdateEvent
            var @event = new ShoppingCartNewPriceIntegrationEvent(model.ProductId, model.NewPrice);
            _eventBus.Publish(@event);
        }
    }
}
