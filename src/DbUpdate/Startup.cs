using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DbUpdate.Model;
using Microsoft.EntityFrameworkCore;
using DbUpdate.Common;

namespace DbUpdate
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = "Filename=sql.db";
            services.AddDbContext<DataContext>(options => options.UseSqlite(connection));
            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseStaticFiles();

            app.UseMvc();            
            //var db = app.ApplicationServices.GetService<DataContext>();
            //db.Database.EnsureCreatedAsync();
            //if (db.SQLConfigs.Count() <= 0)
            //{
            //    db.SQLConfigs.Add(new SQLConfig()
            //    {
            //        Name = "dev",
            //        Connection = "Data Source=.;Initial Catalog=GYOADB;user id=sa;password=sa123456;",
            //        Version = 1
            //    });
            //    db.SaveChanges();
            //}
        }
    }
}
