using System.Collections.Generic;
using System.Threading.Tasks;

namespace FakeProductsProvider.FakeProductsApi
{
    public interface IFakeProductsAsync<T> where T : BaseProducts
    {
        Task<IEnumerable<T>> GetProductsAsync();
        Task<T> GetProductAsync(int id);
    }
}