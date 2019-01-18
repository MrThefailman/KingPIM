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
using KingPIM.Repositories;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity.UI.Services;
using KingPIM.Models.Models;
using KingPIM.Web.Infrastructure;

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

            services.AddSingleton(_configuration);

            // So the Json() in the controller will return correctly:
            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

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

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ISubcategoryRepository, SubcategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductAttributeRepository, ProductAttributeRepository>();
            services.AddTransient<IAttributeGroupRepository, AttributeGroupRepository>();
            services.AddTransient<ISubcategoryAttributeGroup, SubcategoryAttributeGroupRepository>();
            services.AddTransient<IProductAttributeValueRepository, ProductAttributeValueRepository>();
            services.AddTransient<ICustomAttributeGroupOptionsRepository, CustomAttributeGroupOptionsRepository>();

            services.AddTransient<PasswordService>();
            
            services.AddTransient<IIdentitySeeder, IdentitySeeder>();

            
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
            });
            services.AddMemoryCache();
            services.AddSession();

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
                    template: "{controller=Account}/{action=Index}/{userId?}/{code?}");
            });

            var runIdentitySeed = Task.Run(async () => await identitySeeder.CreateAdminAccountIfEmpty()).Result;

            Seed.FillIfEmpty(ctx);

        }
    }
}
