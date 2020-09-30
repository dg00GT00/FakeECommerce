using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ProductsTransformer.JsonServices;

namespace ProductsTransformer.FakeProductsApi
{
    public class GetFakeProductAsync<T> :
        IFakeProductsAsync<T>,
        IDisposable where T : BaseProducts
    {
        private readonly IJsonSerializer<T> _jsonSerializer;
        private readonly BaseFakeProductsApi _productsApi;
        private readonly HttpClient _httpClient;

        public ProductsTypes ProductsType { get; set; } = ProductsTypes.Cloth;

        public GetFakeProductAsync(IJsonSerializer<T> jsonSerializer,
            BaseFakeProductsApi productsApi,
            HttpClient httpClient)
        {
            _jsonSerializer = jsonSerializer;
            _productsApi = productsApi;
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<T>> GetProductsAsync()
        {
            var productUri = _productsApi.UriByProductType(ProductsType);
            var products = await _httpClient.GetStringAsync(productUri);
            return _jsonSerializer.GenerateArray(products);
        }

        public async Task<T> GetProductAsync(int id)
        {
            var productUri = _productsApi.UriByProductType(ProductsType, id);
            var product = await _httpClient.GetStringAsync(productUri);
            return _jsonSerializer.GenerateSingle(product);
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}