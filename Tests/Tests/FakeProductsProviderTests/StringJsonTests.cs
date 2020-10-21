using System;
using System.IO;
using System.Threading.Tasks;
using FakeProductsProvider;
using FakeProductsProvider.JsonServices;
using Tests.FakeProductsProviderTests.BaseSourceTests;
using Xunit;

namespace Tests.FakeProductsProviderTests
{
    public class StringJsonTests : DefaultJsonSerializer, IDisposable
    {
        private string _tempJsonFile;
        private StringJson<BaseProducts> _sut;

        public StringJsonTests()
        {
            _tempJsonFile = Path.GetTempFileName() + ".json";
            _sut = new StringJson<BaseProducts>(JsonSerializer);
        }

        [Fact]
        public async Task WriteReadAsync_FromJsonString_ShouldHaveConsistency()
        {
            // Arrange
            const string sampleJsonString = @"""{
                'test': 'testString',
                'test1': ['item1', 'item2']
            }""";
            // Act
            await _sut.WriteAsync(_tempJsonFile, sampleJsonString);
            // Assert
            var stringJson = await _sut.ReadAsync(_tempJsonFile);
            Assert.Equal(sampleJsonString.Trim(), stringJson.Trim());
        }

        [Fact]
        public async Task WriteReadAsync_FromProductObject_ShouldHaveConsistency()
        {
            // Arrange
            var sampleProductObj = new BaseProducts
            {
                Description = "Test Description",
                Price = 10.00M,
                Title = "Sample Title"
            };
            // Act
            await _sut.WriteAsync(_tempJsonFile, new[] {sampleProductObj});
            var stringJson = await _sut.ReadAsync(_tempJsonFile);
            // Assert
            Assert.Equal(
                JsonSerializer.GenerateString(new[] {sampleProductObj}).Trim(),
                stringJson.Trim());
        }

        public void Dispose()
        {
            File.Delete(_tempJsonFile);
        }
    }
}