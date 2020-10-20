using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FakeProductsProvider.JsonServices
{
    public class StringJson<T> : IStringJsonAsync<T> where T : BaseProducts
    {
        private readonly IJsonSerializer<T> _jsonSerializer;

        /// <summary>
        /// Reads or writes json formatted string from or to a file 
        /// </summary>
        /// <param name="jsonSerializer">A JsonSerializer implementation</param>
        public StringJson(IJsonSerializer<T> jsonSerializer)
        {
            _jsonSerializer = jsonSerializer;
        }

        /// <summary>
        /// Reads from a json file to screen
        /// </summary>
        /// <param name="jsonSource">The json file source</param>
        /// <returns></returns>
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

        /// <summary>
        /// Writes a json formatted string to a json destination file
        /// </summary>
        /// <param name="jsonDestination">The json file destination</param>
        /// <param name="json">The json formatted string</param>
        /// <returns></returns>
        public async Task WriteAsync(string jsonDestination, string json)
        {
            using var writer = new StreamWriter(jsonDestination);
            foreach (var j in json)
            {
                await writer.WriteAsync(j);
            }
        }

        /// <summary>
        /// Writes a base products collection to a json destination file
        /// </summary>
        /// <param name="jsonDestination">The json destination file</param>
        /// <param name="products">A base products collection</param>
        /// <returns></returns>
        public async Task WriteAsync(string jsonDestination, IEnumerable<T> products)
        {
            var jsonProducts = _jsonSerializer.GenerateString(products);
            await WriteAsync(jsonDestination, jsonProducts);
        }
    }
}