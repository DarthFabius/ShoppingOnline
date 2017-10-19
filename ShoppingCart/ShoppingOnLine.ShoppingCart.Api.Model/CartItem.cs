using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingOnLine.ShoppingCart.Api.Model
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public byte NumberOfProduct { get; set; }
        public DateTime DateOfAdd { get; set; }
    }
}
