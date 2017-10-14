using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ShoppingOnLine.Web.Infrastructure
{
    public class ProductClient:ApiClient
    {
        public ProductClient()
            :base("http://localhost:53000/", "/api/Product")
        {
            
        }

        



    }
}
