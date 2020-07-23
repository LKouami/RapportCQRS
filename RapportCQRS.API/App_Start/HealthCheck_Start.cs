using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;

namespace RapportCQRS.API.App_Start
{
    public static class HealthCheck_Start
    {
        public static void UseHealthCheckAndUI(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddHealthChecks()
                .AddSqlServer(Configuration["ConnectionStrings:DefaultConnection"])
                .AddUrlGroup(new Uri("https://api.simplecast.com/v1/podcasts.json"), "Simplecast API", HealthStatus.Degraded)
                .AddUrlGroup(new Uri("https://rss.simplecast.com/podcasts/4669/rss"), "Simplecast RSS", HealthStatus.Degraded);
            ;

            services.AddHealthChecksUI();
        }
        public static void UseHealthCheckAndUI(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/healthcheck", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI();


        }

    }
}
