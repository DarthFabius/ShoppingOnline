using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShoppingOnline.DomainModel;
using ShoppingOnline.DomainModel.Context;

namespace ShoppingOnline.ConsolleApp
{
    class Program
    {
        public static IConfigurationRoot Configuration;

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();

            var builderEF = new DbContextOptionsBuilder<DbContextUsers>();
            builderEF.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

            using (var db = new DbContextUsers(builderEF.Options))
            {
                var user = new ShoppingUser
                {
                    Email = "fabio.mannis@outlook.com",
                    SecurityInfo = new SecurityUserInfo
                    {
                        Username = "DarthFabius",
                        Password = "pwd.2017!!"                       
                    }
                };

                db.ShoppingUsers.Add(user);

                db.SaveChanges();

                //var items = db.ShoppingUsers.ToList();

                //var i = new SecurityUserInfo
                //{
                //    Password = "pwd.2017",
                //    Username = "fabio.mannis@outlook.com"
                //};

                //db.ShoppingUsers.Add(i);

                //db.SaveChanges();
            }

            //using (var db = DbContextUsersFactory())
            //{
            //    var users = db.ShoppingUsers.ToList();
            //}
        }
    }
}
