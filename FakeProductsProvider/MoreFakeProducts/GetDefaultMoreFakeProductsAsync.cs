using System.Net.Http;
using System.Threading.Tasks;
using FakeProductsProvider.DefaultFakeProducts;
using FakeProductsProvider.JsonServices;

namespace FakeProductsProvider.MoreFakeProducts
{
    public class GetDefaultMoreFakeProductsAsync<T> : GetDefaultFakeProductAsync<T> where T : BaseProducts
    {
        public GetDefaultMoreFakeProductsAsync(
            IJsonSerializer<T> jsonSerializer, 
            BaseFakeProductsApi.BaseFakeProductsApi productsApi,
            HttpClient httpClient) : base(jsonSerializer, productsApi, httpClient)
        {
        }

        public async Task<T> GetProductAsync()
        {
            var product = await HttpClient.GetStringAsync(ProductsApi.BaseUri);
            return JsonSerializer.GenerateSingle(product);
        }
    }
}