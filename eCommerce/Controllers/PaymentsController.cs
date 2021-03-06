using System.IO;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using eCommerce.Errors;
using Infrastructure.Services.PaymentProcessingServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stripe;
using Order = Core.Entities.OrderAggregate.Order;

namespace eCommerce.Controllers
{
    public class PaymentsController : BaseApiController
    {
        private readonly IPaymentService _paymentService;
        private readonly IPaymentProcessingService _paymentProcessing;
        private readonly ILogger<PaymentsController> _logger;

        // This constant string has valid of 90 days
        // Secret to use with stripe
        private const string WhSecret = "whsec_iKaAmZ55SpuQ0JchLQwCltKloEWcovfz";

        public PaymentsController(
            IPaymentService paymentService,
            IPaymentProcessingService paymentProcessing,
            ILogger<PaymentsController> logger)
        {
            _paymentService = paymentService;
            _paymentProcessing = paymentProcessing;
            _logger = logger;
        }

        [HttpPost("{basketId}"), Authorize]
        public async Task<ActionResult<CustomerBasket>> CreateOrUpdatePaymentIntent(string basketId)
        {
            var basket = await _paymentService.CreateOrUpdatePaymentIntent(basketId);
            if (basket is null)
            {
                return BadRequest(new ApiResponse(400, "Problem with your basket"));
            }

            return basket;
        }

        [HttpPost("webhook")]
        public async Task<ActionResult> StripeWebhook()
        {
            var json = await new StreamReader(Request.Body).ReadToEndAsync();
            var stripeEvent = EventUtility.ConstructEvent(json, Request.Headers["Stripe-Signature"], WhSecret);
            PaymentIntent intent;
            Order order;

            switch (stripeEvent.Type)
            {
                case "payment_intent.succeeded":
                    intent = (PaymentIntent) stripeEvent.Data.Object;
                    _logger.LogInformation("Payment Succeeded: {IntentId}", intent.Id);
                    order = await _paymentService.UpdateOrderPaymentSucceeded(intent.Id);
                    _logger.LogInformation("Order updated to payment received: {OrderId}", order?.Id);
                    break;
                case "payment_intent.payment_failed":
                    intent = (PaymentIntent) stripeEvent.Data.Object;
                    order = await _paymentService.UpdateOrderPaymentFailed(intent.Id);
                    _logger.LogInformation("Payment Failed: PaymentIntent: {PaymentIntentId} - Order: {OrderId}",
                        intent.Id, order?.Id);
                    break;
            }

            return Ok();
        }
    }
}