using System.Threading.Tasks;
using ProductsTransformer.CourseFakeProducts;
using ProductsTransformer.FakeProductsApi;
using ProductsTransformer.JsonServices;

namespace ProductsTransformer
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

        public async Task Swap(string newJsonFilePath)
        {
            var courseProducts = await _courseProducts.GetProductsAsync();
            var newCourseProducts = await _newCourseProducts.GetProductsAsync();
            foreach (var cp in courseProducts)
            {
                foreach (var ncp in newCourseProducts)
                {
                    cp.Name = ncp.Title;
                    cp.Description = ncp.Description;
                    cp.Price = ncp.Price;
                    cp.PictureUrl = ncp.Image;
                }
            }

            await _jsonAsync.WriteAsync(newJsonFilePath, courseProducts);
        }
    }
}