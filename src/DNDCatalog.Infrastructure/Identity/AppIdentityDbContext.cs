using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNDCatalog.Infrastructure.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DNDCatalog.Infrastructure.Identity;


//public class AppIdentityDbContextFactory : IDesignTimeDbContextFactory<AppIdentityDbContext>
//{
//    public AppIdentityDbContext CreateDbContext(string[] args)
//    {
//        var optionsBuilder = new DbContextOptionsBuilder<AppIdentityDbContext>();
//        optionsBuilder.UseSqlite("Data Source=identity.sqlite");
//
//        return new AppIdentityDbContext(optionsBuilder.Options);
//    }
//}


public class AppIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
    {
    }

}
