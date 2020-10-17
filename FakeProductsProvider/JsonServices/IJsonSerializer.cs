using System.Collections.Generic;
using System.Text.Json;

namespace FakeProductsProvider.JsonServices
{
    public interface IJsonSerializer<T> where T : class
    {
        public JsonSerializerOptions JsonOptions { get; set; }
        public string GenerateString(IEnumerable<T> obj);
        public T GenerateSingle(string jsonResponse);
        public IEnumerable<T> GenerateArray(string jsonResponse);
    }
}