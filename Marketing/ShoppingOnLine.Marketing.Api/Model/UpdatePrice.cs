using System;
using ShoppingOnline.DomainModel;

namespace ShoppingOnLine.Marketing.Api.Model
{
    public class UpdatePrice
    {
        public int ProductId { get; set; }

        public decimal NewPrice { get; set; }
    }
}
