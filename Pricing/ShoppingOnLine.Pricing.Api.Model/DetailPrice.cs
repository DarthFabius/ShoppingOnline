using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingOnline.DomainModel;

namespace ShoppingOnLine.Pricing.Api.Model
{
    public class DetailPrice
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public CurrencyType Currency { get; set; }
    }
}
