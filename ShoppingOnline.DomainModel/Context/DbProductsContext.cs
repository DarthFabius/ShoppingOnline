using Microsoft.EntityFrameworkCore;

namespace ShoppingOnline.DomainModel.Context
{
    public class DbProductsContext: DbBaseContext
    {
        public DbSet<Products> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().Property(p => p.SerializedProperties);

            base.OnModelCreating(modelBuilder);
        }
    }
}
