using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShoppingOnline.DomainModel;
using ShoppingOnline.DomainModel.Context;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ShoppingOnLineDomainModelContextServiceExtention
    {
        //public static IServiceCollection addDBSellingInfoContext(this IServiceCollection services)
        //{
        //    var appSettings = (IOptions<AppSettings>)services
        //                                                .LastOrDefault(d => d.ServiceType == typeof(IOptions<AppSettings>))
        //                                                ?.ImplementationInstance;

        //    services.AddDbContext<DbSellingInfoContext>(options => {
        //        options.UseSqlServer(appSettings.Value.ConnectionString);
                    
        //        });

        //    return services;
        //}

        public static IServiceCollection addDBSellingInfoContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DbSellingInfoContext>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}
