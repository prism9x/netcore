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

            // Add Service
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserService, UserService>();

            //services.ConfigureApplicationCookie(option =>
            //{
            //    option.Cookie.Name = "BookShopCookie";
            //    option.ExpireTimeSpan = TimeSpan.FromDays(7);
            //    option.LoginPath = "/admin/authencation/login";
            //    option.AccessDeniedPath = "/admin/admin/home";
            //});


            //services.AddTransient<IAppUserRepository, AppUserRepository>();


            // Add RazorPage
            services.AddRazorPages();

            // Add DbContext
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            // Add IdentityUser Service
            services.AddIdentity<AppUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

        }
    }
}
