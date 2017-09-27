using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingOnline.DomainModel;
using ShoppingOnline.DomainModel.Context;

namespace ShoppinOnlineConsolle
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new DbProductsContext(ConfigurationManager.AppSettings["ConnStrig"]))
            {
                var item = new Products
                {
                    Id = Guid.NewGuid(),
                    Description = "Test prodotto",
                    ShortDescription = "TEST1",
                    Properties = new Dictionary<string, string>
                    {
                        {"Item1", "Value1"},
                        {"Item2", "Value2"}
                    }
                };

                db.Products.Add(item);
                db.SaveChanges();

                var items = db.Products.ToList();

                Console.WriteLine(items[0].Id);
            }

            using (var db = new DbContextUsers(ConfigurationManager.AppSettings["ConnStrig"]))
            {
                var items = db.ShoppingUsers.Include(i => i.SecurityInfo).ToList();
                foreach (var item in items)
                {
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.Email);
                    Console.WriteLine(item.SecurityInfo.Id);
                    Console.WriteLine(item.SecurityInfo.Password);
                    Console.WriteLine(item.SecurityInfo.Username);
                    Console.WriteLine(item.SecurityInfo.LastLoginDateTime.ToString("d"));
                }
            }

            using (var db = new DbContextUsers(ConfigurationManager.AppSettings["ConnStrig"]))
            {
                var item = new ShoppingUser
                {
                    Email = "fabio.mannis@gmail.com",
                    Id = Guid.NewGuid(),
                    SecurityInfo = new SecurityUserInfo
                    {
                        Id = Guid.NewGuid(),
                        Password = "pwd.2017!",
                        Username = "fabio.mannis@gmail.com"
                    }
                };

                db.ShoppingUsers.Add(item);

                db.SaveChanges();
            }
        }
    }
}
