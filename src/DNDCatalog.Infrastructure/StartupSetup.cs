using DNDCatalog.Infrastructure.Data;
using DNDCatalog.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DNDCatalog.Infrastructure;
public static class StartupSetup
{
    public static void AddCatalogDbContext(this IServiceCollection services, string connectionString, bool isDevelopment)
    {
        //if(isDevelopment)
            //services.AddDbContext<CatalogDbContext>(options => options.UseSqlite(connectionString)); // will be created in web project root
        //else
            services.AddDbContext<CatalogDbContext>(options => options.UseSqlServer(connectionString)); 
    }

    public static void AddIdentityDbContext(this IServiceCollection services, string connectionString, bool isDevelopment)
    {
        //if (isDevelopment)
            //services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlite(connectionString)); // will be created in web project root
        //else
            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(connectionString));
    }
}
