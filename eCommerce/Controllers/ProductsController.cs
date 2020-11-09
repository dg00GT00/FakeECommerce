using System.Collections.Generic;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using eCommerce.Errors;
using eCommerce.Helpers;
using eCommerce.Models;
using eCommerce.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGetRepository<Product> _getRepo;
        private readonly IPostRepository<Product> _postRepo;
        private readonly IMapper _mapper;

        public ProductsController(
            IGetRepository<Product> getRepo, 
            IPostRepository<Product> postRepo,
            IMapper mapper)
        {
            _getRepo = getRepo;
            _postRepo = postRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts(
            [FromQuery] ProductSpecParamsModel productParamsModel)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productParamsModel);
            var countSpec = new ProductWithFiltersForCountSpecification(productParamsModel);
            var totalItems = await _getRepo.CountEntityAsync(countSpec);
            var products = await _getRepo.ListEntityAsync(spec);
            var mappedProducts = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);
            return Ok(new Pagination<ProductToReturnDto>(
                productParamsModel.PageIndex, productParamsModel.PageSize, totalItems, mappedProducts
            ));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _getRepo.GetEntityWithSpecAsync(spec);
            var mappedProduct = _mapper.Map<Product, ProductToReturnDto>(product);
            return mappedProduct is null
                ? (ActionResult<ProductToReturnDto>) NotFound(new ApiResponse((int) HttpStatusCode.NotFound))
                : Ok(mappedProduct);
        }

        // [HttpPost]
        // [Consumes(MediaTypeNames.Application.Json)]
        // public async ActionResult<ProductToReturnDto> PostProduct(ProductToReturnDto productDto)
        // {
        //     
        // }
    }
}