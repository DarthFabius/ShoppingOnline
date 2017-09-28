using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingOnline.DomainModel;
using ShoppingOnline.DomainModel.Context;

namespace ShoppingOnline.DataAccess
{
    public class SellingInfoDal<T> : IDisposable, IDataAccessLayer<T> where T:class
    {
        private readonly string _connString;
        public SellingInfoDal(string connString)
        {
            _connString = connString;
        }

        public IList<T> GetAll()
        {
            using (var db = new DbSellingInfoContext(_connString))
            {
                return (IList<T>) db.SellingoInfos.ToList();
            }
        }

        public T Get(Guid productId)
        {
            using (var db = new DbSellingInfoContext(_connString))
            {
                return db.SellingoInfos.FirstOrDefault(i => i.Id.Equals(productId)) as T;
            }
        }

        public void Set(T item)
        {
            using (var db = new DbSellingInfoContext(_connString))
            {
                db.Add(item);
                db.SaveChanges();
            }
        }

        public void Update(T item)
        {
            using (var db = new DbSellingInfoContext(_connString))
            {
                db.Update(item);
                db.SaveChanges();
            }
        }

        public void Delete(T item)
        {
            using (var db = new DbSellingInfoContext(_connString))
            {
                db.Remove(item);
                db.SaveChanges();
            }
        }

        public void Dispose()
        {
        }
    }
}
