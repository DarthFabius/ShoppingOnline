using Microsoft.EntityFrameworkCore;

namespace ShoppingOnline.DomainModel.Context
{
    public class DbProductsContext: DbContext
    {
        private static DbContextOptions _contextOptions;

        public DbProductsContext(string connString) : base(_contextOptions)
        {
            var builder = new DbContextOptionsBuilder<DbProductsContext>();
            builder.UseSqlServer(connString);

            _contextOptions = builder.Options;
        }

        public DbProductsContext(DbContextOptions options)
            :base(options)
        {
            _contextOptions = options;
        }

        public DbSet<Products> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().Property(p => p.SerializedProperties);

            base.OnModelCreating(modelBuilder);
        }

        public class DbProductsContextFactory : DesignTimeDbContextFactory<DbProductsContext>
        {        }
    }
}
