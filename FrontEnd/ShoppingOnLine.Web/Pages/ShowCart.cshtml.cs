using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingOnLine.Marketing.Api.Model;
using ShoppingOnLine.ShoppingCart.Api.Model;
using ShoppingOnLine.Web.Infrastructure;

namespace ShoppingOnLine.Web.Pages
{
    public class ShowCartModel : PageModel
    {
        public ShoppingCartCart ShoppingCart { get; set; }

        private ShoppingCartClient _shoppingCartClient;
        private ProductClient _productClient;
        private PricingClient _pricingClient;

        public ShowCartModel(ShoppingCartClient shoppingCartClient, ProductClient productClient, PricingClient pricingClient)
        {
            _shoppingCartClient = shoppingCartClient;
            _productClient = productClient;
            _pricingClient = pricingClient;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var cart = await _shoppingCartClient.GetAsync<Cart>("1");
            var products = await _productClient.GetAsync<IEnumerable<ShoppingOnLine.Marketing.Api.Model.ProductDetail>>();
            var pricings = await _pricingClient.GetAsync<IEnumerable<Pricing.Api.Model.DetailPrice>>();

            ShoppingCart = new ShoppingCartCart()
            {
                CreateDateTime = cart.CreateDateTime,
                Items = cart.Items.Select(p =>
                {
                    var cartItem = new ShoppingCartCartItem()
                    {
                        NumberOfProduct = p.NumberOfProduct,
                        Price = pricings.Where(n=>n.ProductId.Equals(p.ProductId)).Single().Price ,
                        Product = products.Where(m=> m.Id.Equals(p.ProductId) ).Single(),
                        ProductId = p.ProductId
                    };

                    return cartItem;
                }).ToList<ShoppingCartCartItem>()
            };

            return Page();
        }
        

        public async Task<IActionResult> OnGetRemoveAsync(int ProductId)
        {
            await _shoppingCartClient.DeleteAsync(ProductId.ToString());
            return RedirectToPage("ShowCart");
        }

        public class ShoppingCartCart
        {
            public DateTime CreateDateTime { get; set; }
            public List<ShoppingCartCartItem> Items { get; set; }
        }

        public class ShoppingCartCartItem
        {
            public int ProductId { get; set; }
            public decimal Price { get; set; }
            public decimal TotPrice => Price * NumberOfProduct;
            public byte NumberOfProduct { get; set; }

            public ProductDetail Product { get; set; }
        }
    }
}