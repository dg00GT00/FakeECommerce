using System.Collections.Generic;
using System.Text.Json;

namespace FakeProductsProvider.JsonServices
{
    /// <summary>
    /// Manage the json serializer structure
    /// </summary>
    /// <typeparam name="T">A class</typeparam>
    public class JsonSerializerManager<T> : IJsonSerializer<T> where T : class
    {
        public JsonSerializerOptions JsonOptions { get; set; } = new JsonSerializerOptions
            {PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

        /// <summary>
        /// Generates a collection of objects from a json formatted string source 
        /// </summary>
        /// <param name="jsonResponse">The object collection</param>
        /// <returns></returns>
        public IEnumerable<T> GenerateArray(string jsonResponse)
        {
            return JsonSerializer.Deserialize<T[]>(jsonResponse, JsonOptions);
        }

        /// <summary>
        /// Generates a json formatted string from an object
        /// </summary>
        /// <param name="obj">The source object</param>
        /// <returns></returns>
        public string GenerateString(T obj)
        {
            return JsonSerializer.Serialize(obj, JsonOptions);
        }

        /// <summary>
        /// Generates a json formatted string from a collection of objects
        /// </summary>
        /// <param name="obj">The collection of objects</param>
        /// <returns></returns>
        public string GenerateString(IEnumerable<T> obj)
        {
            return JsonSerializer.Serialize(obj, JsonOptions);
        }

        /// <summary>
        /// Generates a single object from a json formatted string
        /// </summary>
        /// <param name="jsonResponse">The json formatted string source</param>
        /// <returns></returns>
        public T GenerateSingle(string jsonResponse)
        {
            return JsonSerializer.Deserialize<T>(jsonResponse, JsonOptions);
        }
    }
}