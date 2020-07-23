using FluentValidation.AspNetCore;
using RapportCQRS.API.Helpers;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Net.Mime;
using System.Reflection;
using RapportCQRS.Domain.Validations;

namespace RapportCQRS.API.App_Start
{
    public static class Mvc_Start
    {
        public static string MyAllowSpecificOrigins = "MyPolicy";


        public static void UseDefaultAndCors(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            services.AddRouting(options => options.LowercaseUrls = true);

            //Inject all dependencies
            services.ResolveDepenciesServices(Configuration);

            services.AddMediatR();

            //Load dynamically
            var assemblyV1 = typeof(RapportCQRS.API.V1.Controllers.ApiV1ControllerBase).Assembly;

            services.AddControllers().AddApplicationPart(assemblyV1);

            services.AddControllersWithViews(opts =>
            {
                opts.Filters.Add<SerilogMvcLoggingAttribute>();
                opts.Filters.Add(new HttpResponseExceptionFilter());
            })
            
             .ConfigureApiBehaviorOptions(options =>
             {
                 options.InvalidModelStateResponseFactory = context =>
                 {

                     var result = new BadRequestObjectResult(new CustomBadRequest(context));

                     // TODO: add `using System.Net.Mime;` to resolve MediaTypeNames
                     result.ContentTypes.Add(MediaTypeNames.Application.Json);
                     result.ContentTypes.Add(MediaTypeNames.Application.Xml);

                     return result;
                 };

             }); ; 

            services.AddRazorPages();

        }
        public static void UseAllMVCAndRouting(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            //You may would disable auto migrate if needed
            //app.UseAutoMigrateDatabase<RapportCQRS_DBContext>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();

            // SeriLog
            app.UseSerilogRequestLogging();

            app.UseRouting();


            //app.UseHttpMetrics();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<SerilogRequestLogger>();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapHealthChecks("/health", options);
                endpoints.MapRazorPages();
                // endpoints.MapMetrics();
            });



        }

    }
}
