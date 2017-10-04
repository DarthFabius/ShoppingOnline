using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ShoppingOnline.DomainModel.Context
{
    public class DbSellingInfoContext : DbContext
    {

        public DbSellingInfoContext(DbContextOptions<DbSellingInfoContext> options) 
            : base(options)
        {
        }

        public DbSet<SellingInfo> SellingoInfos { get; set; }

        //public class DbSellingInfoContextFactory : DesignTimeDbContextFactory<DbSellingInfoContext>
        //{ }
    }
}
