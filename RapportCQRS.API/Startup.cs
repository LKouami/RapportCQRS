using RapportCQRS.API.App_Start;
using RapportCQRS.API.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Employee.API
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            // Read configuration and combine appsettings.json and appsettings.env.json by environment of deployment
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.UseDefaultAndCors(Configuration);

            services.AddAuthorization();

            services.AddAuthentication();

            services.UseSwaggerAndUI();

            // services.UseHealthCheckAndUI(Configuration);

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IHostApplicationLifetime lifetime)
        {
            lifetime.ApplicationStarted.Register(() => {
                Console.WriteLine("Application has started");
            });

            lifetime.ApplicationStopping.Register(() => {
                Console.WriteLine("Application is stopping");
            });

            lifetime.ApplicationStopped.Register(() => {
                Console.WriteLine("Application is shut down");
            });

            app.UseAllMVCAndRouting(env);

           

            //  app.UseHealthCheckAndUI();

            app.UseSwaggerAndUI();

        }


    }
}