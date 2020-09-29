using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using ProductsTransformer.CourseFakeProducts;
using ProductsTransformer.FakeProductsApi;
using ProductsTransformer.JsonServices;

namespace ProductsTransformer
{
    class Program
    {
        private const string BasePath = "/home/dggt/RiderProjects/eCommerce/Infrastructure/Data/";

        static async Task Main(string[] args)
        {
            var jsonAsync = new StringJson<CourseProducts>(new JsonSerializerManager<CourseProducts>());
            var courseProducts = new GetCourseFakeProductsAsync<CourseProducts>(jsonAsync)
            {
                JsonFilePath = BasePath + "CourseSeedData/products.json"
            };
            var newCourseProducts =
                new GetFakeProductAsync<NewCourseProducts>(new BaseFakeProductsApi(), new HttpClient())
                {
                    ProductsType = ProductsTypes.Cloth
                };
            var ps = new SwapProducts(courseProducts, newCourseProducts, jsonAsync);
            await ps.Swap(GenerateJsonFile());
        }

        private static string GenerateJsonFile()
        {
            var directoryInfo = Directory.CreateDirectory(BasePath + "NewCourseSeed");
            return directoryInfo.FullName + "/products.json";
        }
    }
}