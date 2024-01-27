using BookShop.DataAccess.DataAccess;
using BookShop.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.DataAccess
{
    public static class Configuration
    {
        public static void AutoMigration(this WebApplication webApplication)
        {
            using (var scope = webApplication.Services.CreateScope())
            {
                // get DbContext from ServiceProvider of Dependency injection
                var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                appContext.Database.MigrateAsync().Wait();
            }
        }


        public static async void SeedData(this WebApplication webApplication)
        {
            using (var scope = webApplication.Services.CreateScope())
            {
                try
                {

                    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                    #region Role
                    // Role

                    if (!await roleManager.RoleExistsAsync("SuperAdmin"))
                    {
                        await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = "SuperAdmin"
                        });
                    }
                    #endregion

                    #region User
                    // User
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                    var userExist = await userManager.FindByNameAsync("Admin");

                    if (userExist == null)
                    {
                        // Create obj
                        var user = new AppUser
                        {
                            UserName = "Admin",
                            Email = "prism9x@gmail.com",
                            IsActive = true,
                            AccessFailedCount = 0
                        };

                        // Create Db
                        var identityUser = await userManager.CreateAsync(
                              user, "ShopBook@123");

                        if (identityUser.Succeeded)
                        {
                            // Add Role
                            await userManager.AddToRoleAsync(user, "SuperAdmin");
                        }
                    }
                    #endregion
                }

                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
