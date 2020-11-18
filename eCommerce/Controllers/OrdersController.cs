using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using eCommerce.Errors;
using eCommerce.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    [Authorize]
    public class OrdersController : BaseApiController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();
            var address = _mapper.Map<AddressDto, Address>(orderDto.ShipToAddress);
            var order = await _orderService.CreateOrderAsync(email, orderDto.DeliveryMethodId, orderDto.BasketId,
                address);
            if (order == null)
            {
                return BadRequest(new ApiResponse(400, "Problem creating order"));
            }

            HttpContext.Response.StatusCode = (int) HttpStatusCode.Created;
            return order;
        }
    }
}