using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingOnLine.Web.Infrastructure
{
    public class ShoppingCartClient:ApiClient
    {
        public ShoppingCartClient():
            base("http://localhost:52436/", "/Api/ShoppingCart")
        {

        }
    }
}
