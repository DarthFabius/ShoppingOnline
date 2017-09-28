using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ShoppingOnline.DomainModel.Context
{
    public class DbSellingInfoContext : DbContext
    {
        private static DbContextOptions _contextOptions;

        public DbSellingInfoContext(string connString) : base(_contextOptions)
        {
            var builder = new DbContextOptionsBuilder<DbSellingInfoContext>();
            builder.UseSqlServer(connString);

            _contextOptions = builder.Options;
        }

        public DbSellingInfoContext(DbContextOptions options)
            :base(options)
        {
            _contextOptions = options;
        }

        public DbSet<SellingInfo> SellingoInfos { get; set; }

        public class DbSellingInfoContextFactory : DesignTimeDbContextFactory<DbSellingInfoContext>
        { }
    }
}
