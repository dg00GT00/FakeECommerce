using System.Collections.Generic;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Core.Models;
using Core.Specifications;
using eCommerce.Errors;
using eCommerce.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _genericRepo;
        private readonly IPostRepository<Product> _postRepo;
        private readonly IMapper _mapper;

        public ProductsController(
            IGenericRepository<Product> genericRepo,
            IPostRepository<Product> postRepo,
            IMapper mapper)
        {
            _genericRepo = genericRepo;
            _postRepo = postRepo;
            _mapper = mapper;
        }

        [HttpGet, Cached(600)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts(
            [FromQuery] ProductSpecParamsModel productParamsModel)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productParamsModel);
            var countSpec = new ProductWithFiltersForCountSpecification(productParamsModel);
            var totalItems = await _genericRepo.CountEntityAsync(countSpec);
            var products = await _genericRepo.ListEntityAsync(spec);
            var mappedProducts = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);
            return Ok(new Pagination<ProductToReturnDto>(
                productParamsModel.PageIndex, productParamsModel.PageSize, totalItems, mappedProducts
            ));
        }

        [HttpGet("{id}"), Cached(600)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _genericRepo.GetEntityWithSpecAsync(spec);
            var mappedProduct = _mapper.Map<Product, ProductToReturnDto>(product);
            return mappedProduct is null
                ? (ActionResult<ProductToReturnDto>) NotFound(new ApiResponse((int) HttpStatusCode.NotFound))
                : Ok(mappedProduct);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ProductToInsertionDto>> PostProduct(ProductToInsertionDto productDto)
        {
            var product = _mapper.Map<ProductToInsertionDto, Product>(productDto);
            var insertedProduct = await _postRepo.InsertEntityAsync(product);
            return CreatedAtAction(nameof(GetProduct), new {insertedProduct.Id}, insertedProduct);
        }
    }
}