using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ShoppingOnline.DomainModel.Context
{
    public class DbBaseContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connstr = ConfigurationManager.AppSettings["ConnStrig"];
            optionsBuilder.UseSqlServer(connstr);
        }
    }
}
