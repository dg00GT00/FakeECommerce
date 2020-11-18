using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.OrderAggregate;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        public async Task<Order> CreateOrder(string buyerEmail, int deliveryMethod, string basketId,
            Address shippingAddress)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<Order>> GetOrderForUserAsync(string buyerEmail)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}