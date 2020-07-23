using RapportCQRS.API.Helpers;
using RapportCQRS.API.PipelineBehaviors;
using RapportCQRS.Data.IRepositories;
using RapportCQRS.Data.Repositories;
using RapportCQRS.Model;
using RapportCQRS.Domain.Dxos;
using RapportCQRS.Service.Services.Helpers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using RapportCQRS.Model.Models;

namespace RapportCQRS.API.App_Start
{
    public static class Dependencies_Start
    {

        /// <summary>
        /// Resolve all the dependencies in the application
        /// </summary>
        /// <param name="services"></param>
        /// <param name="Configuration"></param>
        public static void ResolveDepenciesServices(this IServiceCollection services, IConfiguration Configuration)
        {
            // //Sql server 
            // //master database
            // services.AddDbContext<RapportCQRS_Master_DbContext>(options =>
            // {
            //     options.UseSqlServer(Configuration.GetConnectionString("MasterConnection"),
            //         sqlOptions =>
            //         {
            //             sqlOptions.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(30),
            //                 errorNumbersToAdd: null);
            //         });
            // });

            //Add connection string based on the tenant. Pick the tenantid in the header
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDbContext<RapportCQRSDbContext>((serviceProvider, options) =>
            {
                var httpContext = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
                var httpRequest = httpContext.Request;
                var connection = GetConnection(httpRequest, Configuration);
                options.UseSqlServer(connection, sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                });
            });




            //Add DIs

            //services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            //services.AddScoped<IDepartmentDxos, DepartmentDxos>();

            //User
            services.AddScoped<ITokenHelper, TokenHelper>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserDxos, UserDxos>();

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleDxos, RoleDxos>();

            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IActivityDxos, ActivityDxos>();

            services.AddScoped<ITimeTableRepository, TimeTableRepository>();
            services.AddScoped<ITimeTableDxos, TimeTableDxos>();



            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        }

        private static string GetConnection(HttpRequest httpRequest, IConfiguration Configuration)
        {
            string tenantId = httpRequest.Headers["TenantId"].ToString();

            Console.WriteLine($"TenantId: {tenantId}");

            if (!string.IsNullOrWhiteSpace(tenantId))
            {
                return Configuration.GetConnectionString("DefaultConnection").Replace("{TenantId}", tenantId);
            }
            else
            {
                return Configuration.GetConnectionString("DefaultConnection").Replace("_{TenantId}", "");
            }


        }
    }
}
