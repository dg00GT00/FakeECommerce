using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsTransformer.JsonServices
{
    public interface IStringJsonAsync<T> where T : BaseProducts
    {
        Task<string> ReadAsync(string jsonSource);
        Task WriteAsync(string jsonDestination, string json);
        Task WriteAsync(string jsonDestination, IEnumerable<T> products);
    }
}