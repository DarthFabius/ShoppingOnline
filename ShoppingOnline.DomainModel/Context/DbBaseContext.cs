using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ShoppingOnline.DomainModel.Context
{
    public class DbBaseContext:DbContext
    {
        private string _connectionString;
        public DbBaseContext(string connectionSting)
        {
            _connectionString = connectionSting;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
