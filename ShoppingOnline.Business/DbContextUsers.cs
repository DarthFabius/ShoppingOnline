using System.Configuration;
using Microsoft.EntityFrameworkCore;
using ShoppingOnline.DomainModel;

namespace ShoppingOnline.Business
{
    public class DbContextUsers : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connstr = ConfigurationManager.AppSettings["ConnStrig"];
            optionsBuilder.UseSqlServer(connstr);
        }
        public DbSet<ShoppingUser> ShoppingUsers { get; set; }
        public DbSet<SecurityUserInfo> SecurityUserInfos { get; set; }
        public DbSet<ShippingInfo> ShippingInfos { get; set; }
    }
}
