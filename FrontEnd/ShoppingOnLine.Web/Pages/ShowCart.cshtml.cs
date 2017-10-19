using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingOnLine.ShoppingCart.Api.Model;
using ShoppingOnLine.Web.Infrastructure;

namespace ShoppingOnLine.Web.Pages
{
    public class ShowCartModel : PageModel
    {
        public Cart cart { get; set; }  
        private ShoppingCartClient _shoppingCartClient;

        public ShowCartModel(ShoppingCartClient shoppingCartClient)
        {
            _shoppingCartClient = shoppingCartClient;
        }

        public async Task<IActionResult> OnGet()
        {
            cart = await _shoppingCartClient.GetAsync<Cart>("1");

            return Page();
        }

    }
}