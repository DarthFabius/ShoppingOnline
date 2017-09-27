﻿using Microsoft.EntityFrameworkCore;

namespace ShoppingOnline.DomainModel.Context
{
    public class DbContextUsers : DbBaseContext
    {
        public DbContextUsers(string connectionString)
            :base(connectionString)
        {        
        }

        public DbSet<ShoppingUser> ShoppingUsers { get; set; }
        public DbSet<SecurityUserInfo> SecurityUserInfos { get; set; }
        public DbSet<ShippingInfo> ShippingInfos { get; set; }
    }
}
