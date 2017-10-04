using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingOnLine.Web.Infrastructure
{
    public class ProductClient:ApiClient
    {
        public ProductClient()
            :base("http://localhost:6740")
        {
        }
    }
}
