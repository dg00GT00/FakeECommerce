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
            var jsCourseProducts = new JsonSerializerManager<CourseProducts>();
            var jsonAsync = new StringJson<CourseProducts>(jsCourseProducts);
            var courseProducts = new GetCourseFakeProductsAsync<CourseProducts>(jsCourseProducts, jsonAsync)
            {
                JsonFilePath = BasePath + "CourseSeedData/products.json"
            };
            using var newCourseProducts =
                new GetFakeProductAsync<NewCourseProducts>(
                    new JsonSerializerManager<NewCourseProducts>(),
                    new BaseFakeProductsApi(),
                    new HttpClient());
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