using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ShoppingOnline.DomainModel.Context
{
    public class DbContextUsers : DbContext
    {
        private static DbContextOptions _contextOptions;

        public DbContextUsers(string connString) : base(_contextOptions)
        {
            var builder = new DbContextOptionsBuilder<DbContextUsers>();
            builder.UseSqlServer(connString);

            _contextOptions = builder.Options;
        }

        public DbContextUsers(DbContextOptions options)
            :base(options)
        {        
        }

        public DbSet<ShoppingUser> ShoppingUsers { get; set; }
        public DbSet<SecurityUserInfo> SecurityUserInfos { get; set; }
        public DbSet<ShippingInfo> ShippingInfos { get; set; }


    }

    public class DbContextUsersFactory : DesignTimeDbContextFactory<DbContextUsers>
    {    }
}
