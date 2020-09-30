using System.Collections.Generic;
using System.Text.Json;

namespace ProductsTransformer.JsonServices
{
    public class JsonSerializerManager<T> : BaseJson, IJsonSerializer<T> where T : BaseProducts
    {
        public IEnumerable<T> GenerateArray(string jsonResponse)
        {
            return JsonSerializer.Deserialize<T[]>(jsonResponse, JsonOptions);
        }

        public string GenerateString(T obj)
        {
            return JsonSerializer.Serialize(obj, JsonOptions);
        }
        
        public string GenerateString(IEnumerable<T> obj)
        {
            return JsonSerializer.Serialize(obj, JsonOptions);
        }
        public T GenerateSingle(string jsonResponse)
        {
            return JsonSerializer.Deserialize<T>(jsonResponse, JsonOptions);
        }
    }
}