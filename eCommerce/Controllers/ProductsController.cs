using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using eCommerce.Dtos;
using eCommerce.Errors;
using eCommerce.Models;
using eCommerce.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _repo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts(
            [FromQuery] ProductSpecParamsModel productParamsModel)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productParamsModel);
            var products = await _repo.ListAsync(spec);
            var mappedProducts = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);
            return Ok(mappedProducts);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _repo.GetEntityWithSpec(spec);
            var mappedProduct = _mapper.Map<Product, ProductToReturnDto>(product);
            return mappedProduct is null
                ? (ActionResult<Product>) NotFound(new ApiResponse((int) HttpStatusCode.NotFound))
                : Ok(mappedProduct);
        }
    }
}