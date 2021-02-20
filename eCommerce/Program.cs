using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Azure.Identity;
using Core.Entities.Identity;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
                    // Service locator block for products database seeding
                    await SeedDbProducts(services, loggerFactory);
                    // Service locator block for identity user seeding
                    await SeedDbIdentity(services);
                }
                catch (Exception e)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(e, "An error occured during migration");
                }
            }

            await host.RunAsync();
        }

        private static async Task SeedDbIdentity(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<AppUser>>();

            var identityContext = services.GetRequiredService<AppIdentityDbContext>();
            await identityContext.Database.MigrateAsync();
            var identitySeed = new AppIdentityDbContextSeed();
            await identitySeed.SeedUserAsync(userManager);
        }

        private static async Task SeedDbProducts(IServiceProvider services, ILoggerFactory loggerFactory)
        {
            var context = services.GetRequiredService<StoreContext>();
            await context.Database.MigrateAsync();
            await StoreContextSeed.SeedAsync(context, loggerFactory);
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    if (!context.HostingEnvironment.IsProduction()) return;
                    var config = builder.Build();
                    builder.AddAzureKeyVault(new Uri(config["KeyVaultId"]), new DefaultAzureCredential());
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel((context, options) =>
                        {
                            // Use the "dotnet dev-certs tool" on windows when creating https certificates
                            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return;
                            // Configuration comes from user-secrets
                            var certificateConfig = context.Configuration.GetSection("Certificate");
                            var certFileName = certificateConfig["FileName"];
                            var certPassword = certificateConfig["Password"];
                            // Configure the Url and ports to bind to
                            // This overrides calls to UseUrls and the ASPNETCORE_URLS environment variable, but will be 
                            // overridden if you call UseIisIntegration() and host behind IIS/IIS Express
                            options.ListenLocalhost(5001, listenOptions =>
                            {
                                listenOptions.UseHttps(certFileName, certPassword);
                                // Should accept HTTP/1.1 and HTTP/2 due to Stripe CLI requirements
                                listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
                            });
                        })
                        .UseDefaultServiceProvider((context, options) =>
                        {
                            // Add checks for dependency injection on development environment 
                            if (context.HostingEnvironment.IsDevelopment())
                            {
                                options.ValidateScopes = true;
                            }
                        })
                        .UseStartup<Startup>();
                });
    }
}