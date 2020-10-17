using System;
using System.Collections.Generic;
using System.Text;
using FakeProductsProvider.DefaultFakeProducts;

namespace FakeProductsProvider.FakeProductsApi
{
    
    /// <summary>
    /// Abstract class that provides default implement of retrieving fake products information
    /// from a dedicate external web api 
    /// </summary>
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

        /// <summary>
        /// Retrieves an url composite from a base address and specific path which
        /// represents the full url for getting a fake product list
        /// </summary>
        /// <param name="productsType">The product types enum</param>
        /// <returns>An url string</returns>
        public string UriByProductType(ProductsTypes productsType)
        {
            return productsType switch
            {
                ProductsTypes.Cloth => GenerateUri(new[] {"/products"}),
                _ => throw new ArgumentOutOfRangeException(nameof(productsType), productsType, null)
            };
        }

        /// <summary>
        /// Retrieves an url composite from a base address and specific path which
        /// represents the full url for getting a single fake product based on its id
        /// </summary>
        /// <param name="productsType">The product types enum</param>
        /// <param name="id">The id correspondent to the fake api rules</param>
        /// <returns>An url string</returns>
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