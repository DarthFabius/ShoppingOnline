using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingOnLine.Marketing.Api.Model
{
    public class InsertPrice
    {
        public int ProductId { get; set; }

        public decimal NewPrice { get; set; }
    }
}
