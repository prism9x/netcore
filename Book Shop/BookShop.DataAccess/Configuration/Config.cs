using BookShop.DataAccess.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.DataAccess.Configuration
{
    public static class Config
    {
        public static void RegisterDb(this IServiceCollection services, IConfiguration config)
        {
            // Get connection string appsettings.json
            var connectionString = config.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            // Add DbContext on Service Container
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            // Add IdentityUser Service
            services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

        }
    }
}
