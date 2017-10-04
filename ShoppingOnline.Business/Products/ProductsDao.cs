using System;
using System.Linq;
using ShoppingOnline.DataAccess;
using ShoppingOnline.DomainModel.Context;

namespace ShoppingOnline.Business.Products
{
    public class ProductsDao
    {
        public DomainModel.Products GetProductsBillingInfo(IDataAccessLayer<DomainModel.SellingInfo> context, DomainModel.Products item)
        {
            var sellingInfo = context.Get(item.Id);

                if (sellingInfo != null)
                    item.BusinessInformation = sellingInfo;
            return item;
        }
    }
}
