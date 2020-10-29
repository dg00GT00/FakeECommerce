using System;
using System.Data.Common;
using Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Tests.eCommerceTests
{
    public class SharedDatabaseFixture : IDisposable
    {
        public DbConnection Connection { get; }

        public int SeedEntries { get; set; } = 3;

        private SQLServerTestsUtils DbUtils { get; } = new SQLServerTestsUtils();

        public SharedDatabaseFixture()
        {
            Connection = new SqlConnection(DbUtils.GetSqlServerConnectionString());
            Seed();
            Connection.Open();
        }

        /// <summary>
        /// Charges the test database with seeding data based on number of entries
        /// </summary>
        private void Seed()
        {
            using var context = CreateContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var testProductList = DbUtils.SqlServerSeedFactory(SeedEntries);
            context.AddRange(testProductList);
            context.SaveChanges();
        }

        public StoreContext CreateContext(DbTransaction transaction = null)
        {
            var context = new StoreContext(
                new DbContextOptionsBuilder<StoreContext>()
                    .UseSqlServer(Connection).Options
            );
            context.Database.UseTransaction(transaction);

            return context;
        }

        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}