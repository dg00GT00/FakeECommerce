using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class BrandsController : BaseApiController
    {
        private readonly IGenericRepository<ProductBrand> _repo;

        public BrandsController(IGenericRepository<ProductBrand> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrand()
        {
            return Ok(await _repo.ListAllEntitiesAsync());
        }
    }
}