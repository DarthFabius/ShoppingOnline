using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShoppingOnLine.Web.Pages.Pricing
{
    public class IndexModel : PageModel
    {

        public IEnumerable<>
        public void OnGet()
        {
        }

        public class DetailPrice
        {
            public int ProductId { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }
        }
    }
}