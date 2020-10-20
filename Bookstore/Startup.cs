using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Data;
using Bookstore.Helpers;
using Bookstore.Models;
using Bookstore.Repository;
using Bookstore.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace Bookstore
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookStoreContext>( options =>
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            
            //Configure Identity server in this application using AddIdentity() and also connect with the DBContext that we are using.
            services.AddIdentity<ApplicationUser, IdentityRole>().
                AddEntityFrameworkStores<BookStoreContext>();

            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/login";
            });

            /*Configure Password settings of Identity Server for ex:-*/
            services.Configure<IdentityOptions>(options =>
            {
                /*options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;*/
                options.SignIn.RequireConfirmedEmail = true;
            });

            //To add MVC to our web apps empty template we use AddControllerWithViews() in ASP.Net Core 3.1.
            services.AddControllersWithViews();
#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation().AddViewOptions(option => {
                option.HtmlHelperOptions.ClientValidationEnabled = true;
            });
#endif

            services.Configure<SMTPConfigModel>(_configuration.GetSection("SMTPConfig"));
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            //Register the custom Claims to user in startup class
            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaimsPrincipalFactory>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailService, EmailService>();
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
            app.UseAuthentication();
            app.UseAuthorization();
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
