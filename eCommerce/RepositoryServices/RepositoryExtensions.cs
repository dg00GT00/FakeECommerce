using Core.Interfaces;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.RepositoryServices
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddProductRepository(this IServiceCollection s)
        {
            return s.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}