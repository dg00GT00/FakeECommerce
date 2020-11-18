using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGetRepository<Order> _orderRepo;
        private readonly IGetRepository<DeliveryMethod> _dmRepo;
        private readonly IGetRepository<Product> _productRepo;
        private readonly IBasketRepository _basketRepo;

        public OrderService(IGetRepository<Order> orderRepo, IGetRepository<DeliveryMethod> dmRepo,
            IGetRepository<Product> productRepo, IBasketRepository basketRepo)
        {
            _dmRepo = dmRepo;
            _orderRepo = orderRepo;
            _productRepo = productRepo;
            _basketRepo = basketRepo;
        }

        public async Task<Order> CreateOrder(string buyerEmail, int deliveryMethodId, string basketId,
            Address shippingAddress)
        {
            // Get basket from the repo
            var basket = await _basketRepo.GetBasketAsync(basketId);
            // Get items from the product repo
            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var productItem = await _productRepo.GetEntityByIdAsync(item.Id);
                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PictureUrl);
                var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }

            // Get delivery method from repo
            var deliveryMethod = await _dmRepo.GetEntityByIdAsync(deliveryMethodId);
            // Calculate subtotal 
            var subtotal = items.Sum(item => item.Price * item.Quantity);
            // Create order
            var order = new Order(items, buyerEmail, shippingAddress, deliveryMethod, subtotal);
            // TODO: Save to db

            // Return the order
            return order;
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