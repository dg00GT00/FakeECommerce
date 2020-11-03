using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using eCommerce.Controllers;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Tests.eCommerceTests.TestsControllers
{
    public class TypesControllerTests : IClassFixture<SharedDatabaseFixture>
    {
        private readonly SharedDatabaseFixture _fixture;
        private readonly GenericRepository<ProductType> _typeRepo;
        private TypesController _sut;

        public TypesControllerTests(SharedDatabaseFixture fixture)
        {
            _fixture = fixture;
            _typeRepo = new GenericRepository<ProductType>(fixture.CreateContext());
            _sut = new TypesController(_typeRepo);
        }

        [Fact]
        public async Task GetTypeProductsAsync_ShouldReturnAListOfProductTypes()
        {
            // Arrange
            // Act
            var types = await _sut.GetProductsTypesAsync();
            // Assert
            var actionResult = Assert.IsType<ActionResult<IReadOnlyList<ProductType>>>(types);
            var typesList =
                Assert.IsAssignableFrom<IReadOnlyList<ProductType>>(((OkObjectResult) actionResult.Result).Value);
            Assert.Equal(_fixture.SeedEntries, typesList.Count);
        }
    }
}