﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingOnLine.Pricing.Api.Model
{
    public class UpdatePrice
    {
        public int ProductId { get; set; }

        public decimal NewPrice { get; set; }
    }
}
