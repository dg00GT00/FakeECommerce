using System.Text.Json;

namespace ProductsTransformer.JsonServices
{
    public class BaseJson
    {
        public JsonSerializerOptions JsonOptions { get; set; } = new JsonSerializerOptions
            {PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
    }
}