using System;
using System.Collections.Generic;

namespace ShoppingOnLine.ShoppingCart.Api.Model
{
    public class Cart
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDateTime { get; set; }
        public List<CartItem> Items { get; set; }
    }
}
