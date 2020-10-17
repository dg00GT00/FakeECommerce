using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FakeProductsProvider.BaseFakeProductsApi;
using FakeProductsProvider.JsonServices;

namespace FakeProductsProvider.DefaultFakeProducts
{
    public class GetDefaultFakeProductAsync<T> :
        IFakeProductsAsync<T>,
        IDisposable where T : BaseProducts
    {
        protected readonly IJsonSerializer<T> JsonSerializer;
        protected readonly BaseFakeProductsApi.BaseFakeProductsApi ProductsApi;
        protected readonly HttpClient HttpClient;

        public ProductsTypes ProductsType { get; set; } = ProductsTypes.Cloth;

        public GetDefaultFakeProductAsync(
            IJsonSerializer<T> jsonSerializer,
            BaseFakeProductsApi.BaseFakeProductsApi productsApi,
            HttpClient httpClient)
        {
            JsonSerializer = jsonSerializer;
            ProductsApi = productsApi;
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<T>> GetProductsAsync()
        {
            var productUri = ProductsApi.UriByProductType(ProductsType);
            var products = await HttpClient.GetStringAsync(productUri);
            return JsonSerializer.GenerateArray(products);
        }

        public async Task<T> GetProductAsync(int id)
        {
            var productUri = ProductsApi.UriByProductType(ProductsType, id);
            var product = await HttpClient.GetStringAsync(productUri);
            return JsonSerializer.GenerateSingle(product);
        }

        public void Dispose()
        {
            HttpClient.Dispose();
        }
    }
}