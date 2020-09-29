using System;
using System.Net.Http;
using System.Threading.Tasks;
using ProductsTransformer.JsonServices;

namespace ProductsTransformer.FakeProductsApi
{
    public class GetFakeProductAsync<T> :
        JsonSerializerManager<T>,
        IFakeProductsAsync<T>,
        IDisposable where T : BaseProducts
    {
        private readonly BaseFakeProductsApi _productsApi;
        private readonly HttpClient _httpClient;

        public ProductsTypes ProductsType { get; set; }

        public GetFakeProductAsync(BaseFakeProductsApi productsApi, HttpClient httpClient)
        {
            _productsApi = productsApi;
            _httpClient = httpClient;
        }

        public async Task<T[]> GetProductsAsync()
        {
            var productUri = _productsApi.UriByProductType(ProductsType);
            var products = await _httpClient.GetStringAsync(productUri);
            return GenerateArray(products);
        }

        public async Task<T> GetProductAsync(int id)
        {
            var productUri = _productsApi.UriByProductType(ProductsType, id);
            var product = await _httpClient.GetStringAsync(productUri);
            return GenerateSingle(product);
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}