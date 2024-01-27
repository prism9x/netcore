using BookShop.Application.Services;
using BookShop.DataAccess.DataAccess;
using BookShop.DataAccess.Repository;
using BookShop.Domain.Abstract;
using BookShop.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.Infarstructure.Configuration
{
    public static class ConfigurationService
    {
        public static void ConfigureIdentity(this IServiceCollection services, IConfiguration config)
        {
            // Get connection string appsettings.json
            var connectionString = config.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            // Add DbContext
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            // Add RazorPage
            services.AddRazorPages();

            // Add Service

            // Add IdentityUser Service
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.SignIn.RequireConfirmedEmail = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(option =>
            {
                option.Cookie.Name = "BookShopCookie";
                option.ExpireTimeSpan = TimeSpan.FromHours(7);
                option.LoginPath = "/Admin/Authentication/Login";

                //option.AccessDeniedPath = "/";
            });

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();







        }
    }
}
