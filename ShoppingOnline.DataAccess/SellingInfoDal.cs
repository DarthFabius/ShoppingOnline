using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingOnline.DomainModel;
using ShoppingOnline.DomainModel.Context;

namespace ShoppingOnline.DataAccess
{
    public class SellingInfoDal<T> : IDisposable, IDataAccessLayer<T> where T:class
    {
        public IList<T> GetAll()
        {
            using (var db = new DbSellingInfoContext())
            {
                return (IList<T>) db.SellingoInfos.ToList();
            }
        }

        public T Get(Guid productId)
        {
            using (var db = new DbSellingInfoContext())
            {
                return db.SellingoInfos.FirstOrDefault(i => i.Id.Equals(productId)) as T;
            }
        }

        public void Set(T item)
        {
            using (var db = new DbSellingInfoContext())
            {
                db.Add(item);
                db.SaveChanges();
            }
        }

        public void Update(T item)
        {
            using (var db = new DbSellingInfoContext())
            {
                db.Update(item);
                db.SaveChanges();
            }
        }

        public void Delete(T item)
        {
            using (var db = new DbSellingInfoContext())
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
