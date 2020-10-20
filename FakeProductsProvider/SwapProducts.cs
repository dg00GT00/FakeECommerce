using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeProductsProvider.BaseFakeProductsApi;
using FakeProductsProvider.CourseFakeProducts;
using FakeProductsProvider.DefaultFakeProducts;

namespace FakeProductsProvider
{
    public class SwapProducts : ISwapProducts<CourseProducts>
    {
        private readonly IFakeProductsAsync<CourseProducts> _courseProducts;
        private readonly IFakeProductsAsync<NewCourseProducts> _newCourseProducts;

        /// <summary>
        /// Swaps the values of the properties from two BaseProduct derived classes
        /// </summary>
        /// <param name="newCourseProducts">The source fake product object for swapping procedure</param>
        /// <param name="courseProducts">The target fake product object for swapping procedure</param>
        public SwapProducts(
            IFakeProductsAsync<NewCourseProducts> newCourseProducts,
            IFakeProductsAsync<CourseProducts> courseProducts
        )
        {
            _courseProducts = courseProducts;
            _newCourseProducts = newCourseProducts;
        }

        /// <summary>
        /// Swaps the source fake product object for the target fake product
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CourseProducts>> SwapAsync()
        {
            var courseProducts = await _courseProducts.GetProductsAsync();
            var newCourseProducts = await _newCourseProducts.GetProductsAsync();
            return courseProducts.Zip(newCourseProducts, (cp, ncp) =>
            {
                cp.Name = ncp.Title;
                cp.Description = ncp.Description;
                cp.Price = ncp.Price;
                cp.PictureUrl = ncp.Image;
                return cp;
            });
        }
    }
}