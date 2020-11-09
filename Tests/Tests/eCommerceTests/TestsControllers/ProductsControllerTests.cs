using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using eCommerce.Controllers;
using eCommerce.Dtos;
using eCommerce.Errors;
using eCommerce.Helpers;
using eCommerce.Models;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Tests.eCommerceTests.TestsControllers
{
    public class ProductsControllerTests : IClassFixture<SharedDatabaseFixture>
    {
        private SharedDatabaseFixture _fixture;
        private ProductsController _sut;

        public ProductsControllerTests(SharedDatabaseFixture fixture)
        {
            _fixture = fixture;
            var productRepo = new GenericRepository<Product>(fixture.CreateContext());
            _sut = DefaultProductArrange(productRepo);
        }

        [Fact]
        public async Task GetProductsAsync_ShouldReturnAListOfProduct()
        {
            // Arrange
            var paramsModel = new ProductSpecParamsModel();
            // Act
            var products = await _sut.GetProducts(paramsModel);
            // Assert
            var actionResult = Assert.IsType<ActionResult<Pagination<ProductDto>>>(products);
            var productList =
                Assert.IsType<Pagination<ProductDto>>(((OkObjectResult) actionResult.Result).Value);
            Assert.Equal(_fixture.SeedEntries, productList.Count);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task GetProductAsync_ShouldReturnDefinitionOfAProductById(int id)
        {
            // Arrange
            var testId = id - 1;
            // Act
            var productById = await _sut.GetProduct(id);
            // Assert
            var actionResult = Assert.IsType<ActionResult<ProductDto>>(productById);
            var product = Assert.IsType<ProductDto>(((OkObjectResult) actionResult.Result).Value);
            Assert.Equal(id, product.Id);
            Assert.Equal($"Name_{testId}", product.Name);
            Assert.Equal($"Description_{testId}", product.Description);
            Assert.Equal($"Picture_{testId}", product.PictureUrl);
            Assert.Equal($"ProductType_{testId}", product.ProductType);
            Assert.Equal($"ProductName_{testId}", product.ProductBrand);
            Assert.Equal(testId, product.Price);
        }

        [Fact]
        public async Task GetProductAsync_WhenNotFoundId_ShouldReturnNotFoundObject()
        {
            // Arrange
            // Act
            var notFoundProduct = await _sut.GetProduct(1000);
            // Assert
            var notFoundResult = Assert.IsAssignableFrom<ActionResult<ProductDto>>(notFoundProduct);
            var apiResponse = Assert.IsType<ApiResponse>(((NotFoundObjectResult) notFoundResult.Result).Value);
            Assert.True(HttpStatusCode.NotFound == (HttpStatusCode) apiResponse.StatusCode);
            Assert.Equal("Resource found, it was not", apiResponse.Message);
        }

        private ProductsController DefaultProductArrange(IGenericRepository<Product> productRepo)
        {
            var mapConfig = new MapperConfiguration(expression =>
            {
                expression.CreateMap<Product, ProductDto>();
                expression.AddProfile<MappingProfiles>();
            });
            var mapper = new Mapper(mapConfig);
            return new ProductsController(productRepo, mapper);
        }
    }
}