using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ProductsTransformer.JsonServices
{
    public class StringJson<T> : IStringJsonAsync<T> where T : BaseProducts
    {
        private readonly IJsonSerializer<T> _jsonSerializer;

        public StringJson(IJsonSerializer<T> jsonSerializer)
        {
            _jsonSerializer = jsonSerializer;
        }

        public async Task<string> ReadAsync(string jsonSource)
        {
            var builder = new StringBuilder();
            using var reader = new StreamReader(jsonSource);
            string line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                builder.AppendLine(line);
            }

            return builder.ToString();
        }

        public async Task WriteAsync(string jsonDestination, string json)
        {
            using var writer = new StreamWriter(jsonDestination);
            foreach (var j in json)
            {
                await writer.WriteAsync(j);
            }
        }

        public async Task WriteAsync(string jsonDestination, T[] products)
        {
            var jsonProducts = _jsonSerializer.GenerateString(products);
            await WriteAsync(jsonDestination, jsonProducts);
        }
    }
}