using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using eCommerce.Controllers;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Tests.eCommerceTests.TestsControllers
{
    public class BrandsControllerTests : IClassFixture<SharedDatabaseFixture>
    {
        private readonly SharedDatabaseFixture _fixture;
        private readonly GenericRepository<ProductBrand> _brandRepo;

        public BrandsControllerTests(SharedDatabaseFixture fixture)
        {
            _fixture = fixture;
            _brandRepo = new GenericRepository<ProductBrand>(fixture.CreateContext());
        }

        [Fact]
        public async Task GetProductBrandAsync_ShouldReturnAListOfProductBrand()
        {
            // Arrange
            var sut = new BrandsController(_brandRepo);
            // Act
            var productBrand = await sut.GetProductBrand();
            // Assert
            var actionResult = Assert.IsType<ActionResult<IReadOnlyList<ProductBrand>>>(productBrand);
            var productBrandList =
                Assert.IsAssignableFrom<IReadOnlyList<ProductBrand>>(((OkObjectResult) actionResult.Result).Value);
            Assert.Equal(_fixture.SeedEntries, productBrandList.Count);
        }
    }
}