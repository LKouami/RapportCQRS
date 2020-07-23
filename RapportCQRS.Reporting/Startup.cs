using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using LBMS.Reporting.Helpers;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.HttpsPolicy;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.DependencyInjection.Extensions;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
//using Telerik.Reporting.Cache.File;
//using Telerik.Reporting.Services;
//using Telerik.Reporting.Services.AspNetCore;

namespace LBMS.Reporting
{
    public class Startup
    {
    //    public static string MyAllowSpecificOrigins = "MyPolicy";
    //    public Startup(IConfiguration configuration)
    //    {
    //        Configuration = configuration;
    //    }

    //    public IConfiguration Configuration { get; }

    //    // This method gets called by the runtime. Use this method to add services to the container.
    //    public void ConfigureServices(IServiceCollection services)
    //    {
    //        services.AddControllers();

    //        services.AddCors(options =>
    //        {
    //            options.AddPolicy(MyAllowSpecificOrigins,
    //            builder =>
    //            {
    //                builder.AllowAnyOrigin()
    //                    .AllowAnyMethod()
    //                    .AllowAnyHeader();
    //            });
    //        });


    //        services.Configure<IISServerOptions>(options =>
    //        {
    //            options.AllowSynchronousIO = true;
    //        });

    //        services.AddRazorPages()
    //.AddNewtonsoftJson();

    //        // Configure dependencies for ReportsController.
    //        services.TryAddSingleton<IReportServiceConfiguration>(sp =>
    //            new ReportServiceConfiguration
    //            {
    //                ReportingEngineConfiguration = ConfigurationHelper.ResolveConfiguration(sp.GetService<IWebHostEnvironment>()),
    //                HostAppId = "ReportingCore3App",
    //                Storage = new FileStorage(),
    //                ReportResolver = new ReportFileResolver(
    //                    System.IO.Path.Combine(sp.GetService<IWebHostEnvironment>().ContentRootPath, "Reports"))
    //                .AddFallbackResolver(new CustomReportResolver())
    //            });;
    //    }

    //    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    //    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    //    {
    //        if (env.IsDevelopment())
    //        {
    //            app.UseDeveloperExceptionPage();
    //        }

    //        //app.UseHttpsRedirection();

    //        app.UseRouting();   

    //        app.UseCors(MyAllowSpecificOrigins);

    //        app.UseAuthorization();

    //        app.UseEndpoints(endpoints =>
    //        {
    //            endpoints.MapControllers();
    //        });
    //    }
    }
}
