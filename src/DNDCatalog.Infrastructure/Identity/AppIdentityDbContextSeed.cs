using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DNDCatalog.Infrastructure.Identity;

public class AppIdentityDbContextSeed
{
    public static async Task SeedAsync(AppIdentityDbContext identityDbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {

        if (identityDbContext.Roles.Any())
        {
            return;
        }

        await roleManager.CreateAsync(new IdentityRole(Roles.ADMINISTRATORS.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Roles.EDITORS.ToString()));

        var editorUserName = "editor@gmail.com";
        var editorUser = new ApplicationUser { UserName = editorUserName, Email = editorUserName };
        await userManager.CreateAsync(editorUser, "qwerty");
        editorUser = await userManager.FindByNameAsync(editorUserName);
        await userManager.AddToRoleAsync(editorUser, Roles.EDITORS.ToString());

        string adminUserName = "admin@gmail.com";
        var adminUser = new ApplicationUser { UserName = adminUserName, Email = adminUserName };
        await userManager.CreateAsync(adminUser, "Qwerty123");
        adminUser = await userManager.FindByNameAsync(adminUserName);
        await userManager.AddToRoleAsync(adminUser, Roles.ADMINISTRATORS.ToString());
        await userManager.AddToRoleAsync(adminUser, Roles.EDITORS.ToString());
    }
}
