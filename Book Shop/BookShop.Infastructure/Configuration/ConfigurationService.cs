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
                options.SignIn.RequireConfirmedAccount = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(option =>
            {
                option.Cookie.Name = "AdminCookie";
                option.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                option.LoginPath = "/Admin/Authentication/Login";
                option.SlidingExpiration = true;
                //option.AccessDeniedPath = "/";
            });

            services.Configure<IdentityOptions>(option =>
            {
                option.Lockout.AllowedForNewUsers = true;
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                option.Lockout.MaxFailedAccessAttempts = 3;
            });

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();







        }
    }
}
