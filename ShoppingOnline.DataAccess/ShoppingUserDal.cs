using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingOnline.DomainModel;
using ShoppingOnline.DomainModel.Context;

namespace ShoppingOnline.DataAccess
{
    public class ShoppingUserDal<T> : IDisposable, IDataAccessLayer<T> where T : class
    {
        private readonly string _connString;
        public ShoppingUserDal(string connString)
        {
            _connString = connString;
        }

        public void Delete(T item)
        {
            using (var db = new DbContextUsers(_connString))
            {
                db.Remove(item);
                db.SaveChanges();
            }
        }

        public void Dispose()
        {
        }

        public T Get(Guid id)
        {
            using (var db = new DbContextUsers(_connString))
            {
                return db.ShoppingUsers.FirstOrDefault(i => i.Id.Equals(id)) as T;
            }
        }

        public IList<T> GetAll()
        {
            using (var db = new DbContextUsers(_connString))
            {
                return (IList<T>)db.ShoppingUsers.ToList();
            }
        }

        public void Set(T item)
        {
            using (var db = new DbContextUsers(_connString))
            {
                db.Add(item);
                db.SaveChanges();
            }
        }

        public void Update(T item)
        {
            using (var db = new DbContextUsers(_connString))
            {
                db.Update(item);
                db.SaveChanges();
            }
        }
    }
}
