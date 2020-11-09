using System.Collections.Generic;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace Tests.eCommerceTests
{
    /// <summary>
    /// Test database collection utilities
    /// </summary>
    public class PostgresTestsUtils
    {
        /// <summary>
        /// Retrieves a connection string from user-secrets provider
        /// </summary>
        /// <returns>The connection string</returns>
        public string GetPostgresConnectionString()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets("4e5bdf0c-9af0-4f39-9b5e-7c9da7ba3dc6")
                .Build();
            return config.GetConnectionString("TestsDatabase");
        }

        /// <summary>
        /// Creates a list of products for seeding a test database
        /// </summary>
        /// <param name="seedEntries">The number of entries that products list should have</param>
        /// <returns>A list of products</returns>
        public IEnumerable<Product> PostgresSeedFactory(int seedEntries)
        {
            var productList = new List<Product>();
            for (int i = 0; i < seedEntries; i++)
            {
                // Don't set Ids for SQL Server due to Identity Insert feature
                productList.Add(new Product
                {
                    Name = $"Name_{i}",
                    Description = $"Description_{i}",
                    PictureUrl = $"Picture_{i}",
                    Price = i,
                    ProductType = new ProductType {Name = $"ProductType_{i}"},
                    ProductBrand = new ProductBrand {Name = $"ProductName_{i}"},
                });
            }

            return productList;
        }
    }
}