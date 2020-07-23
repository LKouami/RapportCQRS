using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace Employee.API
{
#pragma warning disable CS1591
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                                       .AddJsonFile("appsettings.json")
                                       .Build();

            Log.Logger = new LoggerConfiguration()
                                        .Enrich.FromLogContext()
                                        .Destructure.ToMaximumDepth(100)
                                        .Enrich.WithProperty("Application", "MainApi")
                                        .ReadFrom.Configuration(configuration)
                                        .CreateLogger();

            Serilog.Debugging.SelfLog.Enable(Console.Error);

            try
            {
                Console.WriteLine("Application starting up");
                Log.Information("Application starting up");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {

                Console.Error.WriteLine($"error - {ex.Message}");
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Console.WriteLine("Application ended");
                Log.Information("Application ended");
                Log.CloseAndFlush();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
#pragma warning restore CS1591
}