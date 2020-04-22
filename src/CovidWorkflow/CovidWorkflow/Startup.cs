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
            //Scaffold-DbContext 'Data Source=.;Initial Catalog=WorkflowCovid;UID=sa;PWD=<YourStrong@Passw0rd>' Microsoft.EntityFrameworkCore.SqlServer -OutputDir ModelsSqlServer            
            services
                .AddDbContext<WorkflowCovidContext>(opt=> 
                opt.UseInMemoryDatabase("Test"));

            services.AddCors(options =>
            {
                options.AddPolicy(name: "ALL",
                             builder =>
                             {
                                 builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                             });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("ALL");
            }
            app.UseStaticFiles();
            app.UseDefaultFiles();
            //app.UseHttpsRedirection();

            app.UseRouting();

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
