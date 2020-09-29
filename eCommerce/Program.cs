using System;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace eCommerce
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = services.GetRequiredService<StoreContext>();
                    await context.Database.MigrateAsync();
                }
                catch (Exception e)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(e, "An error occured during migration");
                }
            }
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel((context, options) =>
                    {
                        var certificateConfig = context.Configuration.GetSection("Certificate");
                        var certFileName = certificateConfig["FileName"];
                        var certPassword = certificateConfig["Password"];
                        // Configure the Url and ports to bind to
                        // This overrides calls to UseUrls and the ASPNETCORE_URLS environment variable, but will be 
                        // overridden if you call UseIisIntegration() and host behind IIS/IIS Express
                        options.ListenLocalhost(5001, listenOptions =>
                        {
                            listenOptions.UseHttps(certFileName, certPassword);
                            listenOptions.Protocols = HttpProtocols.Http2;
                        });
                    }).UseStartup<Startup>();
                });
    }
}