using System;

namespace ShoppingOnLine.ShoppingCart.Api.Model
{
    public class CartItem
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public byte NumberOfProduct { get; set; }
        public DateTime DateOfAdd { get; set; }
    }
}
