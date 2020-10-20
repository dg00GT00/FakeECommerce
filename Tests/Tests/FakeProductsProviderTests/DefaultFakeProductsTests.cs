using System;
using System.Net.Http;
using System.Threading.Tasks;
using FakeProductsProvider;
using FakeProductsProvider.BaseFakeProductsApi;
using FakeProductsProvider.DefaultFakeProducts;
using Tests.FakeProductsProviderTests.BaseSourceTests;
using Xunit;

namespace Tests.FakeProductsProviderTests
{
    public class DefaultFakeProductsTests : DefaultJsonSerializer, IDisposable
    {
        protected GetDefaultFakeProductAsync<BaseProducts> Sut { get; }

        protected BaseFakeProductsApi BaseApi { get; } = new DefaultFakeProductApi();

        protected HttpClient Client { get; } = new HttpClient();

        public DefaultFakeProductsTests()
        {
            Sut = new GetDefaultFakeProductAsync<BaseProducts>(JsonSerializer, BaseApi, Client);
        }

        [Fact]
        public async Task GetFakeProductsAsync_FromBaseApi_ShouldReturnProductList()
        {
            // Arrange
            // Act
            var products = await Sut.GetProductsAsync();
            // Assert
            foreach (var product in products)
            {
                Assert.False(string.IsNullOrEmpty(product.Description));
                Assert.False(string.IsNullOrEmpty(product.Image));
                Assert.False(string.IsNullOrEmpty(product.Title));
                Assert.True(product.Price > 0.00M);
            }
        }

        public void Dispose()
        {
            Sut.Dispose();
        }
    }
}