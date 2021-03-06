using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;
using FakeProductsProvider.JsonServices;
using Infrastructure.Data;
using Infrastructure.DataExtensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace eCommerce.Helpers
{
    public class StoreContextSeed
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public StoreContextSeed(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        private static Dictionary<string, Type> SeedDictionary { get; } = new Dictionary<string, Type>
        {
            {"brands.json", typeof(ProductBrand)},
            {"types.json", typeof(ProductType)},
            {"products.json", typeof(Product)},
            {"delivery.json", typeof(DeliveryMethod)}
        };

        private string GetFileFullPath(string fileName)
        {
            var rootDir = _hostEnvironment.IsProduction() ? _hostEnvironment.ContentRootPath : "..";
            var seedDirectory = Path.GetFullPath(
                Path.Combine(
                    rootDir,
                    Path.Join("Infrastructure", "Data", "NewCourseSeedData", Path.DirectorySeparatorChar.ToString())),
                Directory.GetCurrentDirectory());
            return new StringBuilder(seedDirectory).Append(fileName).ToString();
        }

        private async Task SeedEntities(StoreContext context)
        {
            foreach (var (jsonFile, entityType) in SeedDictionary)
            {
                var tableName = entityType.Name + "s";
                var productProperty = context.GetType().GetTypeInfo().GetDeclaredProperty(tableName);
                dynamic productEntity = productProperty?.GetValue(context);
                if (!((IQueryable) productEntity)!.Any())
                {
                    var jsonData = await File.ReadAllTextAsync(GetFileFullPath(jsonFile));
                    var jsonSerializerType = typeof(JsonSerializerManager<>).MakeGenericType(entityType);
                    dynamic jsonSerializer = Activator.CreateInstance(jsonSerializerType);
                    jsonSerializer!.JsonOptions = new JsonSerializerOptions();
                    var items = jsonSerializer.GenerateArray(jsonData);
                    foreach (var item in items!)
                    {
                        productEntity!.Add(item);
                    }

                    await context.SqlServerSaveChangesAsync(tableName);
                }
            }
        }

        public async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                await SeedEntities(context);
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(e, e.Message);
            }
        }
    }
}