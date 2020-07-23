using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace RapportCQRS.API.App_Start
{
    public static class Swagger_Start
    {
        public static void UseSwaggerAndUI(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "RapportCQRS Api",
                    Description = "Exercise project",
                    Contact = new OpenApiContact
                    {
                        Name = "Lucas KOUAMI",
                        Email = "@rkouami@outlook.com",
                    }
                });

                c.DescribeAllParametersInCamelCase();

                // Set the comments path for the Swagger JSON and UI.
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });

        }

        public static void UseSwaggerAndUI(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee API V1"); });
        }
    }
}
