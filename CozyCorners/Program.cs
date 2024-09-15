using CozyCorners.Core;
using CozyCorners.Core.Models.Identity;
using CozyCorners.Core.Models;
using CozyCorners.Helpers;
using CozyCorners.Repository;
using CozyCorners.Repository.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CozyCorners
{
    public class Program
    {
        public  static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<CozyDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("conn"));
            });

          

            builder.Services.AddIdentity<AppUser, IdentityRole>()
               .AddEntityFrameworkStores<CozyDbContext>();

            //builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            
           
            builder.Services.AddAutoMapper(typeof(MappingProfiles));
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        
            builder.Services.AddAuthentication("Cookies")
       .AddCookie(options =>
       {
           options.LoginPath = "/Account/Signin"; // Redirect to this path if not authenticated
                                                  // options.AccessDeniedPath = "/Account/AccessDenied"; // Redirect here if the user is authenticated but not authorized
           options.ExpireTimeSpan = TimeSpan.FromMinutes(1);

       });
            builder.Services.ConfigureApplicationCookie(conf =>
            {
                conf.LoginPath = "/Account/Signin";
                conf.LogoutPath = "/Account/Logout";
            });
            builder.Services.AddAuthorization();
            var app = builder.Build();

            #region Update Database

            using var scope = app.Services.CreateScope();

            var services = scope.ServiceProvider;


            var loggerfactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                var dbcontext = services.GetRequiredService<CozyDbContext>();
                //Ask Clr for creating object from dbcontext Explicitly

                await dbcontext.Database.MigrateAsync();

                //var usermanager = services.GetRequiredService<UserManager<AppUser>>();
                //await AppSeed.UserSeedAsync(usermanager);

            }
            catch (Exception ex)
            {
                var logger = loggerfactory.CreateLogger(typeof(Program));
                logger.LogError(ex, "An Error Occured During Apply Migration ");

            }


            #endregion
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
           app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

			app.MapControllerRoute(
			  name: "admin",
			  pattern: "Admin/{controller=Home}/{action=IndexAdmin}/{id?}");

			app.Run();
        }
    }
}
