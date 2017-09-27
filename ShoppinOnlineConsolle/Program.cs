using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingOnline.Business;
using ShoppingOnline.DomainModel;

namespace ShoppinOnlineConsolle
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new DbContextUsers())
            {
                var items = db.ShoppingUsers.Include(i=>i.SecurityInfo).ToList();
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

            using (var db = new DbContextUsers())
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
