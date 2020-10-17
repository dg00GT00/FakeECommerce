using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using FakeProductsProvider.BaseFakeProductsApi;
using FakeProductsProvider.JsonServices;

namespace FakeProductsProvider.CourseFakeProducts
{
    public class GetCourseFakeProductsAsync<T> : IFakeProductsAsync<T> where T : BaseProducts
    {
        public string JsonFilePath { get;}
        private readonly IJsonSerializer<T> _jsonSerializer;
        private readonly IStringJsonAsync<T> _stringJsonAsync;

        public GetCourseFakeProductsAsync(
            IJsonSerializer<T> jsonSerializer,
            IStringJsonAsync<T> stringJsonAsync,
            string jsonFilePath)
        {
            _jsonSerializer = jsonSerializer;
            _stringJsonAsync = stringJsonAsync;
            JsonFilePath = jsonFilePath;
        }

        public async Task<IEnumerable<T>> GetProductsAsync()
        {
            var json = await _stringJsonAsync.ReadAsync(JsonFilePath);
            _jsonSerializer.JsonOptions = new JsonSerializerOptions();
            return _jsonSerializer.GenerateArray(json);
        }

        public Task<T> GetProductAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}