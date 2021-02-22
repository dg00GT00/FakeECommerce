using System.Linq;
using Core.Interfaces;
using eCommerce.Errors;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Infrastructure.Services;
using Infrastructure.Services.PaymentProcessingServices;
using Infrastructure.Services.PaymentProcessingServices.Interfaces;
using Infrastructure.Services.WebSocketsService;
using Infrastructure.Services.WebSocketsService.Interfaces;
using Infrastructure.Services.WebSocketsService.WebSocketsServiceMiddleware;
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
        /// <param name="service"></param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection service)
        {
            service.AddSingleton<IResponseCacheService, ResponseCacheService>();
            service.AddSingleton<IPaymentProcessingService, PaymentProcessingService>();
            service.AddSingleton<IPaymentWebSocketsService, PaymentWebSocketsService>();
            service.AddScoped<WebSocketServiceMiddleware>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<ITokenServices, TokenServices>();
            service.AddScoped<IOrderService, OrderService>();
            service.AddScoped<IPaymentService, PaymentService>();
            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddScoped(typeof(IPostRepository<>), typeof(PostRepository<>));
            service.AddScoped<IBasketRepository, BasketRepository>();

            // It reformat some possible Model state errors in order to complaint to ApiResponse implementation
            service.Configure<ApiBehaviorOptions>(options =>
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
            return service;
        }
    }
}