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

        private TestDatabaseUtils DbUtils { get; } = new TestDatabaseUtils();

        public SharedDatabaseFixture()
        {
            Connection = new SqlConnection(DbUtils.GetConnectionString());
            Seed(3);
            Connection.Open();
        }

        /// <summary>
        /// Charges the test database with seeding data based on number of entries
        /// </summary>
        /// <param name="seedEntries">The of items that a table in test database should have</param>
        private void Seed(int seedEntries)
        {
            using var context = CreateContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var testProductList = DbUtils.SeedFactory(seedEntries);
            context.AddRange(testProductList);
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