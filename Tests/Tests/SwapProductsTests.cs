using System.Threading.Tasks;
using FakeProductsProvider;
using FakeProductsProvider.CourseFakeProducts;
using FakeProductsProvider.DefaultFakeProducts;
using Tests.BaseSourceTests;
using Xunit;

namespace Tests
{
    public class SwapProductsTests
    {
        [Fact]
        public async Task SwapFakeProductsAsync_FromSourceToTarget_ShouldReturnASwappedFakeProduct()
        {
            // Arrange
            var sourceFakeProduct = new NewCourseProducts
            {
                Description = "Test Source Description",
                Image = "Test Source Image",
                Price = 10.00M,
                Title = "Test Source Title"
            };
            var targetFakeProduct = new CourseProducts
            {
                Description = "Test Target Description",
                PictureUrl = "Test Target Image",
                Price = 20.00M,
                Name = "Test Target Title"
            };
            var sourceJsonDump = new GetTestBaseProduct<NewCourseProducts>(sourceFakeProduct);
            var targetJsonDump = new GetTestBaseProduct<CourseProducts>(targetFakeProduct);
            // Act
            var sut = new SwapProducts(sourceJsonDump, targetJsonDump);
            var swappedProducts = await sut.SwapAsync();
            // Assert
            Assert.All(swappedProducts, product =>
            {
                Assert.Equal("Test Source Description", product.Description);
                Assert.Equal("Test Source Image", product.PictureUrl);
                Assert.Equal("Test Source Title", product.Name);
                Assert.Equal(10.00M, product.Price);
            });
        }
    }
}