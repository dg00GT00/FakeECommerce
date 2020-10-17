using System.Linq;
using Core.Interfaces;
using eCommerce.Errors;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Extensions
{
    public static class ApplicationExtensions
    {
        /// <summary>
        /// WARNING: This extension must be located at the end of services pipeline due to manipulation with
        /// ModelState behavior
        /// </summary>
        /// <param name="s">The IServiceCollection instance</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection s)
        {
            s.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            s.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState
                        .Where(pair => pair.Value.Errors.Count > 0)
                        .SelectMany(pair => pair.Value.Errors)
                        .Select(error => error.ErrorMessage).ToArray();
                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(errorResponse);
                };
            });
            return s;
        }
    }
}