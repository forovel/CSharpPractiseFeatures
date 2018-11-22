using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleCoreServer.Web.Controllers;
using SimpleCoreServer.Web.Extensions;
using SimpleCoreServer.Web.Middleware;
using SimpleCoreServer.Web.Services;
using System;

namespace SimpleCoreServer.Web
{
    public class Startup
    {
        IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISimpleService, SimpleService>();
            services.AddTransient<HomeController>();
            services.AddDistributedMemoryCache();
            services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(10));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseSession();

            app.UseHeaderMiddleware();

            app.Map("/Home", home =>
            {
                home.Run(async context =>
                {
                    var controller = home.ApplicationServices.GetService<HomeController>();
                    await controller.Index(context);
                });
            });

            app.Map("/Session", session =>
            {
                session.Run(async context =>
                {
                    await SessionSample.SessionAsync(context);
                });
            });

            app.Run(async (context) =>
            {
                string result = string.Empty;
                switch (context.Request.Path.Value.ToLower())
                {
                    case "/header":
                        result = RequestAndResponseSample.GetRequestInformation(context.Request);
                        break;
                    case "/add":
                        result = RequestAndResponseSample.QueryString(context.Request);
                        break;
                    case "/form":
                        result = RequestAndResponseSample.GetForm(context.Request);
                        break;
                    case "/cookiew":
                        result = RequestAndResponseSample.WriteCookie(context.Response);
                        break;
                    case "/cookier":
                        result = RequestAndResponseSample.ReadCookie(context.Request);
                        break;
                }
                await context.Response.WriteAsync(result);
            });
        }
    }
}
