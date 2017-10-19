using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingOnline.DomainModel;
using ShoppingOnLine.Marketing.Api.Model;
using ShoppingOnLine.Pricing.Api.Model;
using ShoppingOnLine.ShoppingCart.Api.Model;
using ShoppingOnLine.Web.Infrastructure;

namespace ShoppingOnLine.Web.Pages
{
    public class IndexModel : PageModel
    {
        [FromBody]
        public int ProductID { get; set; }
        public IEnumerable<DetailProductModel> DataModel { get; set; }

        private ProductClient _productClient;
        private PricingClient _pricingClient;
        private ShoppingCartClient _shoppingCartClient;

        public IndexModel(ProductClient productClient, PricingClient pricingClient, ShoppingCartClient shoppingCartClient)
        {
            _productClient = productClient;
            _pricingClient = pricingClient;
            _shoppingCartClient = shoppingCartClient;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var Pricing = await _pricingClient.GetAsync<IEnumerable<DetailPrice>>();
            var Products = await _productClient.GetAsync<IEnumerable<ProductDetail>>();

            var data = new Dictionary<int, DetailProductModel>();

            foreach (var item in Pricing)
            {
                data.Add(item.ProductId, new DetailProductModel()
                {
                    Amount = item.Price,
                    Currency = item.Currency,
                    ProductId = item.ProductId
                });
            }

            foreach (var item in Products)
            {
                if (data.ContainsKey(item.Id))
                {
                    data[item.Id].Description = item.Description;
                    data[item.Id].ShortDescription = item.ShortDescription;
                }
            }

            DataModel = data.Values;

            return Page();
        }

        public async Task<IActionResult> OnPostAddCartAsync(int ProductID)
        {
            var item = new CartItem()
            {
                ProductId = ProductID,
                NumberOfProduct = 1,
                DateOfAdd = DateTime.Now
            };

            await _shoppingCartClient.PutAsync<CartItem>("1", item);

            return RedirectToPage("index");
        }


        public class DetailProductModel
        {
            public int ProductId { get; set; }
            public decimal Amount { get; set; }
            public CurrencyType Currency { get; set; }
            public string Description { get; set; }
            public string ShortDescription { get; set; }
        }
    }
}
