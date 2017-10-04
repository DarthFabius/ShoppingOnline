using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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

        public static IServiceCollection AddDbInfoContext<T>(this IServiceCollection services, string connectionString)
            where T : DbContext
        {
            services.AddDbContext<T>(options => options.UseSqlServer(connectionString));

            return services;
        }

        //public static IServiceCollection addDBSellingInfoContext(this IServiceCollection services, string connectionString)
        //{
        //    services.AddDbContext<DbSellingInfoContext>(options => options.UseSqlServer(connectionString));

        //    return services;
        //}
    }
}
