using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ShoppingOnline.DomainModel;

namespace ShoppingOnline.DataAccess
{
    public interface IDataAccessLayer<T> where T : class
    {
        IList<T> GetAll();
        T Get(Guid productId);
        void Set(T item);
        void Update(T item);
        void Delete(T item);
    }
}
