using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class TypesController : BaseApiController
    {
        private readonly IGetRepository<ProductType> _repo;

        public TypesController(IGetRepository<ProductType> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductsTypesAsync()
        {
            return Ok(await _repo.ListAllEntitiesAsync());
        }
    }
}