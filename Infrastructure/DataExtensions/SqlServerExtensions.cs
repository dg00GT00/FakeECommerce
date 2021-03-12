using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataExtensions
{
    public static class SqlServerExtensions
    {
        public static async Task SqlServerSaveChangesAsync(this DbContext c, string tableName)
        {
            await c.Database.OpenConnectionAsync();
            try
            {
                var dbName = c.Database.GetDbConnection().Database;
                await c.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT {dbName}.Dev.{tableName} ON");
                await c.SaveChangesAsync();
                await c.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT {dbName}.Dev.{tableName} OFF");
            }
            finally
            {
                await c.Database.CloseConnectionAsync();
            }
        }
    }
}