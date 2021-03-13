using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Services.PaymentProcessingServices.Interfaces;
using Microsoft.Extensions.Configuration;
using Stripe;
using Order = Core.Entities.OrderAggregate.Order;
using Product = Core.Entities.Product;

namespace Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentProcessingService _paymentProcessing;
        private readonly IConfigurationSection _stripeKeys;

        public PaymentService(
            IBasketRepository basketRepository,
            IUnitOfWork unitOfWork,
            IConfiguration config,
            IPaymentProcessingService paymentProcessing
        )
        {
            _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
            _paymentProcessing = paymentProcessing;
            // Come from "dotnet user-secrets"
            _stripeKeys = config.GetSection("StripeSettings");
        }

        public async Task<CustomerBasket?> CreateOrUpdatePaymentIntent(string basketId)
        {
            StripeConfiguration.ApiKey = _stripeKeys["SecretKey"];
            var basket = await _basketRepository.GetBasketAsync(basketId);
            if (basket is null)
            {
                return null;
            }

            var shippingPrice = 0m;

            if (basket.DeliveryMethodId.HasValue)
            {
                var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>()
                    .GetEntityByIdAsync((int) basket.DeliveryMethodId);
                shippingPrice = deliveryMethod.Price;
            }

            foreach (var item in basket.Items)
            {
                var productItem = await _unitOfWork.Repository<Product>().GetEntityByIdAsync(item.ProductId);
                if (item.Price != productItem.Price)
                {
                    item.Price = productItem.Price;
                }
            }

            var service = new PaymentIntentService();
            if (string.IsNullOrEmpty(basket.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long) basket.Items.Sum(item => item.Quantity * item.Price * 100) +
                             (long) shippingPrice * 100,
                    Currency = "usd",
                    PaymentMethodTypes = new List<string> {"card"}
                };
                var intent = await service.CreateAsync(options);
                basket.PaymentIntentId = intent.Id;
                basket.ClientSecret = intent.ClientSecret;
            }
            else
            {
                var options = new PaymentIntentUpdateOptions
                {
                    Amount = (long) basket.Items.Sum(item => item.Quantity * item.Price * 100) +
                             (long) shippingPrice * 100
                };
                await service.UpdateAsync(basket.PaymentIntentId, options);
            }

            await _basketRepository.UpdateBasketAsync(basket);
            return basket;
        }

        public async Task<Order?> UpdateOrderPaymentSucceeded(string paymentIntentId)
        {
            var spec = new OrderByPaymentIdSpecification(paymentIntentId);
            var order = await _unitOfWork.Repository<Order>().GetEntityWithSpecAsync(spec);
            if (order is null)
            {
                _paymentProcessing.ProcessingStatus = false;
                return null;
            }

            order.Status = OrderStatus.PaymentReceived;
            _unitOfWork.Repository<Order>().UpdateEntity(order);
            await _unitOfWork.Complete();
            _paymentProcessing.ProcessingStatus = false;
            return order;
        }

        public async Task<Order?> UpdateOrderPaymentFailed(string paymentIntentId)
        {
            var spec = new OrderByPaymentIdSpecification(paymentIntentId);
            var order = await _unitOfWork.Repository<Order>().GetEntityWithSpecAsync(spec);
            if (order is null)
            {
                _paymentProcessing.ProcessingStatus = false;
                return null;
            }

            order.Status = OrderStatus.PaymentFailed;
            await _unitOfWork.Complete();
            _paymentProcessing.ProcessingStatus = false;
            return order;
        }
    }
}