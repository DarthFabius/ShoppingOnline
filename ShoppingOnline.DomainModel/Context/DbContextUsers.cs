using Microsoft.EntityFrameworkCore;

namespace ShoppingOnline.DomainModel.Context
{
    public class DbContextUsers : DbBaseContext
    {
        public DbSet<ShoppingUser> ShoppingUsers { get; set; }
        public DbSet<SecurityUserInfo> SecurityUserInfos { get; set; }
        public DbSet<ShippingInfo> ShippingInfos { get; set; }
    }
}
