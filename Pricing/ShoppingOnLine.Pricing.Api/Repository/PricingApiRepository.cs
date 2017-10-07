﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingOnline.DomainModel.Context;
using ShoppingOnline.DomainModel;
using ShoppingOnLine.EventBus.Abstraction;
using ShoppingOnLine.Pricing.Api.Model;
using ShoppingOnLine.Pricing.Api.Event;


namespace ShoppingOnLine.Pricing.Api.Repository
{
    public class PricingApiRepository
    {
        private DbSellingInfoContext _db;
        private IEventBus _eventBus;

        public PricingApiRepository(IEventBus eventBus, DbSellingInfoContext db)
        {
            _db = db;
            _eventBus = eventBus;
        }
        public bool InsertPricing(InsertPrice insertPrice)
        {
            var model = new SellingInfo()
            {
                Amount= insertPrice.Amount,
                ProductId = insertPrice.ProductId,
                Currency = insertPrice.Currency
            };

            _db.Add(model);
            _db.SaveChanges();

            return true;
        }

        public bool UpdatePrice(UpdatePrice updatePrice)
        {
            var product = _db.SellingoInfos.FirstOrDefault(i => i.ProductId.Equals(updatePrice.ProductId));
            product.Amount = updatePrice.NewPrice;

            _db.Update(product);
            _db.SaveChanges();


            //Release event ShoppingCartUpdateEvent
            var @event = new PricingOnPriceChange(updatePrice.ProductId, updatePrice.NewPrice);
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
