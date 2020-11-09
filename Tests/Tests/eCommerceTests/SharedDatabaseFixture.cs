using System;
using System.Data.Common;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Tests.eCommerceTests
{
    public class SharedDatabaseFixture : IDisposable
    {
        public DbConnection Connection { get; }

        public int SeedEntries { get; set; } = 3;

        private PostgresTestsUtils DbUtils { get; } = new PostgresTestsUtils();

        public SharedDatabaseFixture()
        {
            Connection = new NpgsqlConnection(DbUtils.GetSqlServerConnectionString());
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
                    .UseNpgsql(Connection).Options
            );
            if (transaction != null)
            {
                context.Database.UseTransaction(transaction);
            }

            return context;
        }

        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}