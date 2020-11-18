using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    /// <summary>
    /// Declares methods for inserting products into the database
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPostRepository<T> where T : Product
    {
        Task<T> InsertEntityAsync(T product);
    }
}