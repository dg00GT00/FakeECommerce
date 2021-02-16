using System.IO;
using AutoMapper;
using eCommerce.Extensions;
using eCommerce.Helpers;
using eCommerce.Middleware;
using Infrastructure.Data;
using Infrastructure.Identity;
using Infrastructure.Services.WebSocketsService.WebSocketsServiceMiddleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;

namespace eCommerce
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        private IConfiguration Configuration { get; }
        private IWebHostEnvironment Env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IConnectionMultiplexer>(provider =>
            {
                var configuration = ConfigurationOptions.Parse(Configuration.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(configuration);
            });
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddDbContext<StoreContext>(options =>
            {
                // Connection strings comes from User secrets
                options.UseNpgsql(Configuration.GetConnectionString("DevDatabase"));
                // options.EnableSensitiveDataLogging();
            });
            services.AddDbContext<AppIdentityDbContext>(options =>
            {
                // Connection strings comes from User secrets
                options.UseNpgsql(Configuration.GetConnectionString("IdentityDatabase"));
            });
            services.AddIdentityServices(Configuration);
            services.AddSwaggerDocumentation();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    // Cors to front-end React application
                    builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
                });
            });
            // This service must be located at the end of the service pipeline
            services.AddApplicationServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseRouting();

            if (Env.IsProduction())
            {
                // Middleware for serving the built client application
                app.UseStaticFiles();
                // Middleware for serving generic static files
                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Content"))
                });
            }

            app.UseWebSockets();

            app.UseMiddleware<WebSocketServiceMiddleware>();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSwaggerDocumentation();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToController("Index", "Fallback");
            });
        }
    }
}