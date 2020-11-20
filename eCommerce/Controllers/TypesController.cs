using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using eCommerce.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class TypesController : BaseApiController
    {
        private readonly IGenericRepository<ProductType> _repo;

        public TypesController(IGenericRepository<ProductType> repo)
        {
            _repo = repo;
        }

        [HttpGet, Cached(600)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductsTypesAsync()
        {
            return Ok(await _repo.ListAllEntitiesAsync());
        }
    }
}