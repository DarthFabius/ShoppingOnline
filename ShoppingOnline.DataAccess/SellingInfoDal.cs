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
        private DbSellingInfoContext _db;
        public SellingInfoDal(string connString, DbSellingInfoContext db)
        {
            _connString = connString;
            _db = db;
        }

        public IList<T> GetAll()
        {
            return (IList<T>) _db.SellingoInfos.ToList();
        }

        public T Get(Guid productId)
        {
           return _db.SellingoInfos.FirstOrDefault(i => i.Id.Equals(productId)) as T;
        }

        public void Set(T item)
        {
            _db.Add(item);
            _db.SaveChanges();
        }

        public void Update(T item)
        {
            _db.Update(item);
            _db.SaveChanges();
        }

        public void Delete(T item)
        {
            _db.Remove(item);
            _db.SaveChanges();
         }

        public void Dispose()
        {
        }
    }
}
