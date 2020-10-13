using Core.Interfaces;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.RepositoryServices
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddProductRepository(this IServiceCollection s)
        {
            s.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return s;
        }
    }
}