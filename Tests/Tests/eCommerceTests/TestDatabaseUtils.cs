using System.Collections.Generic;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace Tests.eCommerceTests
{
    public class TestDatabaseUtils
    {
        /// <summary>
        /// Retrieves a connection string from user-secrets provider
        /// </summary>
        /// <returns>The connection string</returns>
        public string GetConnectionString()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets("4e5bdf0c-9af0-4f39-9b5e-7c9da7ba3dc6")
                .Build();
            return config["ConnectionStrings:TestsDatabase"];
        }

        /// <summary>
        /// Creates a list of products for seeding a test database
        /// </summary>
        /// <param name="seedEntries">The number of entries that products list should have</param>
        /// <returns>A list of products</returns>
        public List<Product> SeedFactory(int seedEntries)
        {
            var productList = new List<Product>();
            for (int i = 0; i < seedEntries; i++)
            {
                productList.Add(new Product
                {
                    Id = i,
                    Name = $"Name_{i}",
                    Description = $"Description_{i}",
                    PictureUrl = $"Picture_{i}",
                    Price = i,
                    ProductType = new ProductType {Id = i, Name = $"ProductType_{i}"},
                    ProductBrand = new ProductBrand {Id = i, Name = $"ProductName_{i}"},
                    ProductBrandId = i,
                    ProductTypeId = i
                });
            }

            return productList;
        }
    }
}