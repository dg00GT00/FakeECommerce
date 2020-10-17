using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsTransformer.FakeProductsApi
{
    public abstract class BaseFakeProductsApi
    {
        public string BaseUri { get; } = "https://fakestoreapi.com";

        private string GenerateUri(IEnumerable<string> pathArray)
        {
            var builder = new StringBuilder(BaseUri);
            foreach (var p in pathArray)
            {
                builder.Append(p);
            }

            return builder.ToString();
        }

        public string UriByProductType(ProductsTypes productsType)
        {
            return productsType switch
            {
                ProductsTypes.Cloth => GenerateUri(new[] {"/products"}),
                _ => throw new ArgumentOutOfRangeException(nameof(productsType), productsType, null)
            };
        }

        public string UriByProductType(ProductsTypes productsType, int id)
        {
            return productsType switch
            {
                ProductsTypes.Cloth => GenerateUri(new[] {"/product", id.ToString()}),
                _ => throw new ArgumentOutOfRangeException(nameof(productsType), productsType, null)
            };
        }
    }
}