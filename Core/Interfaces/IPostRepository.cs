using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IPostRepository<T> where T : Product
    {
        Task<T> InsertEntityAsync(T product);
    }
}