using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.DataExtensions;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using ProductsTransformer.JsonServices;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        private const string SeedDirectory =
            "/home/dggt/RiderProjects/eCommerce/Infrastructure/Data/NewCourseSeedData/";

        private static Dictionary<string, Type> SeedDictionary { get; } = new Dictionary<string, Type>
        {
            {"brands.json", typeof(ProductBrand)},
            {"types.json", typeof(ProductType)},
            {"products.json", typeof(Product)}
        };

        private static string GeFileFullPath(string fileName)
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
                if (!((IQueryable) productEntity)!.Any())
                {
                    var jsonData = await File.ReadAllTextAsync(GeFileFullPath(jsonFile));
                    var jsonSerializerType = typeof(JsonSerializerManager<>).MakeGenericType(entityType);
                    dynamic jsonSerializer = Activator.CreateInstance(jsonSerializerType);
                    jsonSerializer!.JsonOptions = new JsonSerializerOptions();
                    var items = jsonSerializer.GenerateArray(jsonData);
                    foreach (var item in items!)
                    {
                        productEntity!.Add(item);
                    }
                    await context.SqlServerSaveChangesAsync(dbName);
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