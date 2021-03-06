﻿using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingOnline.DomainModel;
using ShoppingOnline.DomainModel.Context;
using ShoppingOnLine.EventBus.Abstraction;
using ShoppingOnLine.Marketing.Api.Model;
using ShoppingOnLine.Pricing.Api.Event;

namespace ShoppingOnLine.Marketing.Api.Repository
{
    public class MarketingApiRepository
    {
        IEventBus _eventBus;
        private DbProductsContext _db;

        public MarketingApiRepository(IEventBus eventBus, DbProductsContext db)
        {
            _eventBus = eventBus;
            _db = db;
        }
        
        public IEnumerable<ProductDetail> getAllProduct()
        {
            return _db.Products.ToList().Select( p => {
                    return new ProductDetail()
                    {
                        Id = p.Id,
                        Description = p.Description,
                        ShortDescription = p.ShortDescription,
                        Properties = p.Properties
                    };
                }).ToList();
        }

        public IEnumerable<ProductDetail> getProducts(IEnumerable<int> id)
        {
            return _db.Products.Where(w => id.Contains(w.Id)).ToList().Select(p => {
                return new ProductDetail()
                {
                    Id = p.Id,
                    Description = p.Description,
                    ShortDescription = p.ShortDescription,
                    Properties = p.Properties
                };
            }).ToList();
        }
    }
}
