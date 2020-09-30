using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsTransformer.FakeProductsApi;
using ProductsTransformer.JsonServices;

namespace ProductsTransformer.CourseFakeProducts
{
    public class GetCourseFakeProductsAsync<T> : JsonSerializerManager<T>, IFakeProductsAsync<T> where T : BaseProducts
    {
        public string JsonFilePath { get; set; }
        private readonly IStringJsonAsync<T> _stringJsonAsync;

        public GetCourseFakeProductsAsync(IStringJsonAsync<T> stringJsonAsync)
        {
            _stringJsonAsync = stringJsonAsync;
        }

        public async Task<IEnumerable<T>> GetProductsAsync()
        {
            var json = await _stringJsonAsync.ReadAsync(JsonFilePath);
            return GenerateArray(json);
        }

        public Task<T> GetProductAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}