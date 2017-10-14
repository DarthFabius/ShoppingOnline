using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingOnLine.Web.Infrastructure
{
    public class PricingClient:ApiClient
    {
        public PricingClient()
            :base("http://localhost:49851/", "/Api/Pricing")
        {
        
        }
    }
}
