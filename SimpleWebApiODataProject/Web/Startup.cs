using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Web.Context;
using Web.Models;
using Web.Services;

namespace Web
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
            services.AddDbContext<ApplicationContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );
            services.AddTransient<BookService>();
            services.AddOData();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, BookService bookService)
        {
            bookService.CreateDatabase();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var builder = new ODataConventionModelBuilder(app.ApplicationServices);
            builder.EntitySet<Book>("Books");
            builder.EntitySet<BookChapter>("Chapters");

            app.UseMvc(routeBuilder => {
                routeBuilder.MapODataServiceRoute("OdataRoute", "odata", builder.GetEdmModel());
                //activate additional odata options
                routeBuilder.Select().Filter().Expand().OrderBy().MaxTop(100).Count();
            });
        }
    }
}
