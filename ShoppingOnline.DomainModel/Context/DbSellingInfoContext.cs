using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ShoppingOnline.DomainModel.Context
{
    public class DbSellingInfoContext : DbBaseContext
    {
        public DbSet<SellingInfo> SellingoInfos { get; set; }
    }
}
