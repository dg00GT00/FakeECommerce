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
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        // The seed directory path behaviors dynamically based on OS
        private static readonly string SeedDirectory = Path.GetFullPath(
                Path.Combine(
                    "..", 
                    Path.Join("Infrastructure", "Data", "NewCourseSeedData", Path.DirectorySeparatorChar.ToString())),
                Directory.GetCurrentDirectory()
            );

        private static Dictionary<string, Type> SeedDictionary { get; } = new Dictionary<string, Type>
        {
            {"brands.json", typeof(ProductBrand)},
            {"types.json", typeof(ProductType)},
            {"products.json", typeof(Product)},
            {"delivery.json", typeof(DeliveryMethod)}
        };

        private static string GetFileFullPath(string fileName)
        {
            return new StringBuilder(SeedDirectory).Append(fileName).ToString();
        }

        private static async Task SeedEntities(StoreContext context)
        {
            foreach (var (jsonFile, entityType) in SeedDictionary)
            {
                var dbName = entityType.Name + "s";
                var productProperty = context.GetType().GetTypeInfo().GetDeclaredProperty(dbName);
                dynamic productEntity = productProperty?.GetValue(context);
                if (!((IQueryable)productEntity)!.Any())
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

                    await context.SaveChangesAsync();
                }
            }
        }

        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
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