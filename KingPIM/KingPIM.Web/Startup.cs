using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPIM.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using KingPIM.Data.DataAccess;

namespace KingPIM.Web
{
    public class Startup
    {
        // configurations to get info from appsettings.JSON
        IConfiguration _configuration;
        public Startup(IConfiguration conf)
        {
            _configuration = conf;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Service for Identity seeder
            services.AddTransient<IIdentitySeeder, IdentitySeeder>();

            // Config for database connection
            var conn = _configuration.GetConnectionString("KingPIM");
            // Registers the service for the database
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(conn));

            // Register service for Identity and Identity roles
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext ctx, IIdentitySeeder identitySeeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");

                routes.MapRoute(
                    name: "AttributeGroup",
                    template: "{controller=AttributeGroup}/{action=Index}");

                routes.MapRoute(
                    name: "Category",
                    template: "{controller=Category}/{action=Index}");

                routes.MapRoute(
                    name: "Account",
                    template: "{controller=Account}/{action=Index}");
            });

            identitySeeder.CreateAdminAccountIfEmpty();

            Seed.FillIfEmpty(ctx);

        }
    }
}
