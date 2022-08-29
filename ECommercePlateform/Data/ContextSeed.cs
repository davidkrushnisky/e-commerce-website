using ECommercePlateform.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommercePlateform.Data
{
    public class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
                //Seed Roles
                await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Client.ToString()));
            
        }
    }
}
