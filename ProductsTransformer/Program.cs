﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
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
            var json = await File.ReadAllTextAsync(GenerateJsonFile("NewCourseSeedData"));
            var jsonSerializerType = typeof(JsonSerializerManager<>).MakeGenericType(typeof(CourseProducts));
            dynamic jsonSerializer = Activator.CreateInstance(jsonSerializerType);
            var products = jsonSerializer?.GenerateArray(json);
            // var genProductArray = jsonSerializer.GetMethod("GenerateArray");
            // var products = genProductArray?.Invoke(jsonSerializer, new[] {json});
            Console.WriteLine(products);


            // var jsCourseProducts = new JsonSerializerManager<CourseProducts>();
            // var jsonAsync = new StringJson<CourseProducts>(jsCourseProducts);
            // var courseProducts = new GetCourseFakeProductsAsync<CourseProducts>(jsCourseProducts, jsonAsync)
            // {
            //     JsonFilePath = BasePath + "CourseSeedData/products.json"
            // };
            // using var newCourseProducts =
            //     new GetFakeProductAsync<NewCourseProducts>(
            //         new JsonSerializerManager<NewCourseProducts>(),
            //         new BaseFakeProductsApi(),
            //         new HttpClient());
            // var ps = new SwapProducts(courseProducts, newCourseProducts, jsonAsync);
            // await ps.SwapAsync(GenerateJsonFile("NewCourseSeed"));
        }

        private static string GenerateJsonFile(string directory)
        {
            var directoryInfo = Directory.CreateDirectory(BasePath + directory);
            return directoryInfo.FullName + "/products.json";
        }
    }
}