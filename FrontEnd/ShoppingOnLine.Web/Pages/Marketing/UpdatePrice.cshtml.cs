using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShoppingOnLine.Web.Pages.Marketing
{
    public class UpdatePriceModel : PageModel
    {
        [BindProperty]
        public UpdatePriceDataModel Price { get; set; }

        public void OnGet()
        {
        }



        public class UpdatePriceDataModel
        {
            public int ProductId { get; set; }
            public decimal NewPrice { get; set; }
        }
    }
}