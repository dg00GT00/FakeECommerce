using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IGetRepository<T> where T : BaseEntity
    {
        Task<T> GetEntityByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllEntitiesAsync();

        Task<T> GetEntityWithSpecAsync(ISpecification<T> spec);

        Task<IReadOnlyList<T>> ListEntityAsync(ISpecification<T> spec);

        Task<int> CountEntityAsync(ISpecification<T> spec);
    }
}