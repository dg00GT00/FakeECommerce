using Core.Entities.OrderAggregate;

namespace Core.Specifications
{
    public class OrderByPaymentIdSpecification : BaseSpecification<Order>
    {
        public OrderByPaymentIdSpecification(string paymentIntendId) : base(order =>
            order.PaymentIntentId == paymentIntendId)
        {
        }
    }
}