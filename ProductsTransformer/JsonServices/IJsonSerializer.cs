using System.Collections.Generic;

namespace ProductsTransformer.JsonServices
{
    public interface IJsonSerializer<T> where T : BaseProducts
    {
        public string GenerateString(IEnumerable<T> obj);
        public T GenerateSingle(string jsonResponse);
        public IEnumerable<T> GenerateArray(string jsonResponse);
    }
}