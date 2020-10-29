using System;
using System.Threading.Tasks;
using Core.Entities;
using eCommerce.Controllers;
using Infrastructure.Data.Repositories;
using Xunit;

namespace Tests.eCommerceTests.TestsControllers
{
    public class BrandsControllerTests : IClassFixture<SharedDatabaseFixture>, IDisposable
    {
        private readonly SharedDatabaseFixture _fixture;

        private readonly GenericRepository<ProductBrand> _brandRepo;

        public BrandsControllerTests(SharedDatabaseFixture fixture)
        {
            _fixture = fixture;
            _brandRepo = new GenericRepository<ProductBrand>(fixture.CreateContext());
        }

        [Fact]
        public async Task GetProductBrand_ShouldReturnAListOfProductBrand()
        {
            var sut = new BrandsController(_brandRepo);
            var brandList = (await sut.GetProductBrand()).Value;
            Assert.Equal(_fixture.SeedEntries, brandList.Count);
        }

        public void Dispose()
        {
            _fixture.Dispose();
        }
    }
}