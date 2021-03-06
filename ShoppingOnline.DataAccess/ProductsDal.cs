﻿using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingOnline.DomainModel.Context;

namespace ShoppingOnline.DataAccess
{
    public class ProductsDal<T> : IDisposable, IDataAccessLayer<T> where T : class
    {
        private readonly string _connString;
        public ProductsDal(string connectionString)
        {
            _connString = connectionString;
        }

        public IList<T> GetAll()
        {
            using (var db = new DbProductsContext(_connString))
            {
                return (IList<T>) db.Products.ToList();
            }
        }

        public T Get(Guid productId)
        {
            using (var db = new DbProductsContext(_connString))
            {
                return db.Products.FirstOrDefault(i => i.Id.Equals(productId)) as T;
            }
        }

        public void Set(T item)
        {
            using (var db = new DbProductsContext(_connString))
            {
                db.Add(item);
                db.SaveChanges();
            }
        }

        public void Update(T item)
        {
            using (var db = new DbProductsContext(_connString))
            {
                db.Update(item);
                db.SaveChanges();
            }
        }

        public void Delete(T item)
        {
            using (var db = new DbProductsContext(_connString))
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
