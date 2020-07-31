using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Data;
using Bookstore.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace Bookstore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookStoreContext>( options =>
            options.UseSqlServer("Server=.;Database=Bookstore;Integrated Security=true;"));
            //To add MVC to our web apps empty template we use AddControllerWithViews() in ASP.Net Core 3.1.
            services.AddControllersWithViews();
#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
            services.AddScoped<BookRepository, BookRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /*app.Use(async (context, next)=>
            {
                await context.Response.WriteAsync("Welcome to 1st Middleware.");
                await next();
                await context.Response.WriteAsync("Response from 1st Middleware.");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Welcome from 2nd Middleware.");
                await next();
            });*/
            app.UseStaticFiles();

            /*To use the Custom StaticFiles, need to set middleware for it like below
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "MyStaticFiles")),
                RequestPath = "/MyStaticFiles"
            });*/

            app.UseRouting();
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapDefaultControllerRoute();
            });

            /*app.UseEndpoints(endpoints =>
            {
                endpoints.Map("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });*/

            /*app.UseEndpoints(endpoints =>
            {
                endpoints.Map("/Shashwat", async context =>
                {
                    if(env.IsDevelopment())
                    {
                        await context.Response.WriteAsync("This is: "+env.EnvironmentName+" Environment");
                    }
                    else if(env.IsProduction())
                    {
                        await context.Response.WriteAsync("This is: " + env.EnvironmentName + " Environment");
                    }
                    else if(env.IsStaging())
                    {
                        await context.Response.WriteAsync("This is: " + env.EnvironmentName + " Environment");
                    }
                    else if(env.IsEnvironment("Shashwat"))
                        await context.Response.WriteAsync("This is: " + env.EnvironmentName + " Environment");
                    else
                        await context.Response.WriteAsync("This is: " + env.EnvironmentName + " Environment");
                });
            });*/
        }
    }
}
