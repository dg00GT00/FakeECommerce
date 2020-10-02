using Core.Interfaces;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.RepositoryServices
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddProductRepositories(this IServiceCollection s)
        {
            s.AddScoped<IProductRepository, ProductRepository>();
            s.AddScoped<IProductBrandRepository, ProductBrandRepository>();
            s.AddScoped<IProductTypeRepository, ProductTypeRepository>();
            return s;
        }
    }
}