using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FakeProductsProvider.BaseFakeProductsApi;
using FakeProductsProvider.JsonServices;

namespace FakeProductsProvider.DefaultFakeProducts
{
    /// <summary>
    /// Retrieves the default implementation of the fake products web api
    /// </summary>
    /// <typeparam name="T">Either BaseProduct class or derived</typeparam>
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

        /// <summary>
        /// Gets a list of fake products
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetProductsAsync()
        {
            var productUri = ProductsApi.UriByProductType(ProductsType);
            var products = await HttpClient.GetStringAsync(productUri);
            return JsonSerializer.GenerateArray(products);
        }

        /// <summary>
        /// Gets a single product by its id
        /// </summary>
        /// <param name="id">The id from the fake product web api</param>
        /// <returns></returns>
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