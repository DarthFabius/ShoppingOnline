using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingOnLine.Marketing.Api.Model
{
    public class ProductDetail
    {
        public int Id { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public IDictionary<string, string> Properties { get; set; }
    }
}
