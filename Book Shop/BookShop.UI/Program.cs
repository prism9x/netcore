using BookShop.DataAccess;
using BookShop.Infarstructure.Configuration;
namespace BookShop.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.ConfigureIdentity(builder.Configuration);

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddControllersWithViews();
            builder.Services.AddLogging(logging =>
            {
                // Bạn có thể cấu hình các nhà cung cấp log ở đây
                logging.AddConsole();
                logging.AddDebug();
                // ... và các cấu hình khác
            });


            var app = builder.Build();

            // Auto migration
            app.AutoMigration();
            app.SeedData();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "AdminRouting",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");




            app.MapRazorPages();

            app.Run();
        }
    }
}
