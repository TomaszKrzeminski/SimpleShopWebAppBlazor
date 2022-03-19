using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using SimpleShopWebApp.Data;
using SimpleShopWebApp.Models;

namespace SimpleShopWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

       
        public void ConfigureServices(IServiceCollection services)
        {



            services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")),
    contextLifetime: ServiceLifetime.Transient,
    optionsLifetime: ServiceLifetime.Singleton);

            


            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDbContextFactory<ApplicationDbContext>();
           

            services.AddIdentity<IdentityUser, IdentityRole>()
           .AddEntityFrameworkStores<ApplicationDbContext>()
           .AddDefaultUI()
           .AddDefaultTokenProviders();





           

            services.AddAuthorizationCore();


            services.AddControllersWithViews();
            ////

            services.AddScoped<UserManager<IdentityUser>>();           

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; }); ;
        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
            });

            SeedData data = new SeedData(context);
            data.EnsurePopulated();

        }
    }
}
