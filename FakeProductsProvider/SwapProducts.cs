using System.Linq;
using System.Threading.Tasks;
using FakeProductsProvider.CourseFakeProducts;
using FakeProductsProvider.DefaultFakeProducts;
using FakeProductsProvider.FakeProductsApi;
using FakeProductsProvider.JsonServices;

namespace FakeProductsProvider
{
    public class SwapProducts
    {
        private readonly IFakeProductsAsync<CourseProducts> _courseProducts;
        private readonly IFakeProductsAsync<NewCourseProducts> _newCourseProducts;
        private readonly IStringJsonAsync<CourseProducts> _jsonAsync;

        public SwapProducts(
            IFakeProductsAsync<CourseProducts> courseProducts,
            IFakeProductsAsync<NewCourseProducts> newCourseProducts,
            IStringJsonAsync<CourseProducts> jsonAsync)
        {
            _courseProducts = courseProducts;
            _newCourseProducts = newCourseProducts;
            _jsonAsync = jsonAsync;
        }

        public async Task SwapAsync(string newJsonFilePath)
        {
            var courseProducts = await _courseProducts.GetProductsAsync();
            var newCourseProducts = await _newCourseProducts.GetProductsAsync();
            var result = courseProducts.Zip(newCourseProducts, (cp, ncp) =>
            {
                cp.Name = ncp.Title;
                cp.Description = ncp.Description;
                cp.Price = ncp.Price;
                cp.PictureUrl = ncp.Image;
                return cp;
            });
            await _jsonAsync.WriteAsync(newJsonFilePath, result);
        }
    }
}