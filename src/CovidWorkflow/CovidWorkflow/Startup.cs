using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidDB.ModelsSqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetCore2Blockly;

namespace CovidWorkflow
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
            services.AddControllers();
            services
                .AddDbContext<WorkflowCovidContext>(opt=>
                //opt.UseInMemoryDatabase("Test")
                opt.UseSqlite("Data Source=sqlitedemo.db")
               // opt.UseSqlServer("Data Source=.;Initial Catalog=WorkflowCovid1;UID=sa;PWD=<YourStrong@Passw0rd>")
         
                );

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwroot";
            });
            services.AddCors(options =>
            {
                options.AddPolicy(name: "ALL",
                             builder =>
                             {
                                 builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                             });
            });
            services.AddBlockly();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("ALL");
            }
            app.UseBlockly();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            

            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseSpa(c => { });
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            var sp = app.ApplicationServices;
            using var scope = sp.CreateScope();
            
            using var db= scope.ServiceProvider.GetService<WorkflowCovidContext>();
            db.CreateDB();
            
        }
    }
}
