using System.Net.Http;
using System.Threading.Tasks;
using ProductsTransformer.FakeProductsApi;
using ProductsTransformer.JsonServices;

namespace ProductsTransformer.FakeProductsProvider
{
    public class GetMoreFakeProductsAsync<T> : GetFakeProductAsync<T> where T : BaseProducts
    {
        public GetMoreFakeProductsAsync(IJsonSerializer<T> jsonSerializer, BaseFakeProductsApi productsApi,
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