using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Releasers;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Microsoft.EntityFrameworkCore;
using ShoppingOnline.DataAccess;
using ShoppingOnline.DomainModel;
using ShoppingOnline.DomainModel.Context;

namespace ShoppinOnlineConsolle
{
    class Program
    {
        private static IWindsorContainer _container;
        static void Init()
        {
            _container = new WindsorContainer(new XmlInterpreter());
            _container.Kernel.ReleasePolicy = new LifecycledComponentsReleasePolicy(_container.Kernel);
            
        }

        static void Main(string[] args)
        {
            Init();

            var dao = _container.Resolve<IDataAccessLayer<Products>>("ProductsDal");

            var items = dao.GetAll();


            //using (var db = new DbProductsContext())
            //{
            //    var item = new Products
            //    {
            //        Id = Guid.NewGuid(),
            //        Description = "Test prodotto",
            //        ShortDescription = "TEST1",
            //        Properties = new Dictionary<string, string>
            //        {
            //            {"Item1", "Value1"},
            //            {"Item2", "Value2"}
            //        }
            //    };

            //    db.Products.Add(item);
            //    db.SaveChanges();

            //    var items = db.Products.ToList();

            //    Console.WriteLine(items[0].Id);
            //}

            ////using (var db = new DbContextUsers())
            ////{
            ////    var items = db.ShoppingUsers.Include(i => i.SecurityInfo).ToList();
            ////    foreach (var item in items)
            ////    {
            ////        Console.WriteLine(item.Id);
            ////        Console.WriteLine(item.Email);
            ////        Console.WriteLine(item.SecurityInfo.Id);
            ////        Console.WriteLine(item.SecurityInfo.Password);
            ////        Console.WriteLine(item.SecurityInfo.Username);
            ////        Console.WriteLine(item.SecurityInfo.LastLoginDateTime.ToString("d"));
            ////    }
            //}

            //using (var db = new DbContextUsers())
            //{
            //    var item = new ShoppingUser
            //    {
            //        Email = "fabio.mannis@gmail.com",
            //        Id = Guid.NewGuid(),
            //        SecurityInfo = new SecurityUserInfo
            //        {
            //            Id = Guid.NewGuid(),
            //            Password = "pwd.2017!",
            //            Username = "fabio.mannis@gmail.com"
            //        }
            //    };

            //    db.ShoppingUsers.Add(item);

            //    db.SaveChanges();
            //}
        }
    }
}
