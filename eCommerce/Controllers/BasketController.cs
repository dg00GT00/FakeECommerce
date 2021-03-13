using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById([FromQuery] string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);
            return Ok(basket ?? new CustomerBasket {UserEmail = id});
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto basket)
        {
            var customerBasket = _mapper.Map<CustomerBasketDto, CustomerBasket>(basket);
            var updatedBasket = await _basketRepository.UpdateBasketAsync(customerBasket);
            return CreatedAtAction(nameof(GetBasketById), new {updatedBasket.UserEmail}, updatedBasket);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasketAsync([FromQuery] string id)
        {
            var deleted = await _basketRepository.DeleteBasketAsync(id);
            return deleted ? (ActionResult) NoContent() : NotFound();
        }
    }
}