using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingOnline.DomainModel;

namespace ShoppingOnLine.Pricing.Api.Model
{
    public class InsertPrice
    {
        public int ProductId { get; set; }

        public decimal Amount { get; set; }

        public CurrencyType Currency { get; set; }

    }
}
