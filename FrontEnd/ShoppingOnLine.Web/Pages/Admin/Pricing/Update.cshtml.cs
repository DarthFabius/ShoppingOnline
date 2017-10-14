using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingOnline.DomainModel;
using ShoppingOnLine.Marketing.Api.Model;
using ShoppingOnLine.Pricing.Api.Model;
using ShoppingOnLine.Web.Infrastructure;

namespace ShoppingOnLine.Web.Pages.Admin.Pricing
{
    public class UpdateModel : PageModel
    {
        private ProductClient _productClient;
        private PricingClient _pricingClient;

        [FromRoute]
        public int ProductId { get; set; }
        [BindProperty]
        public DetailProductModel DataModel { get; set; }

        public UpdateModel(ProductClient productClient, PricingClient pricingClient)
        {
            _productClient = productClient;
            _pricingClient = pricingClient;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var Pricing = await _pricingClient.GetAsync<IEnumerable<DetailPrice>>(ProductId.ToString());
            var Products = await _productClient.GetAsync<IEnumerable<ProductDetail>>(ProductId.ToString());

            DataModel = new DetailProductModel()
            { 
                Amount = Pricing.First().Price,
                Currency = Pricing.First().Currency,
                ProductId = Pricing.First().ProductId
            };
            
            DataModel.Description = Products.First().Description;
            DataModel.ShortDescription = Products.First().ShortDescription;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            UpdatePrice updatePrice = new UpdatePrice()
            {
                NewPrice = DataModel.Amount,
                ProductId = DataModel.ProductId
            };

            await _pricingClient.PutAsync<UpdatePrice>(DataModel.ProductId.ToString(), updatePrice);

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