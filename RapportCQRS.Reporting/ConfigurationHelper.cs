using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBMS.Reporting
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

    static class ConfigurationHelper
    {
        public static IConfiguration ResolveConfiguration(IWebHostEnvironment environment)
        {
            var reportingConfigFileName = System.IO.Path.Combine(environment.ContentRootPath, "appsettings.json");
            return new ConfigurationBuilder()
                .AddJsonFile(reportingConfigFileName, true)
                .Build();
        }
    }
}
