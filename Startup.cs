using Assignment3.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<MovieDbContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:MoviesConnection"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "Movies",
                    "movies",
                    new { Controller = "Home", action = "Movies" });
                endpoints.MapControllerRoute(
                    "add",
                    "movies/add",
                    new { Controller = "Home", action = "AddMovie" });
                endpoints.MapControllerRoute(
                    "edit",
                    "movies/edit/{mid:int}",
                    new { Controller = "Home", action = "EditMovie" });
                endpoints.MapControllerRoute(
                    "delete",
                    "movies/delete/{mid:int}",
                    new { Controller = "Home", action = "DeleteMovie" });
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
