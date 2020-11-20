using Core.Entities.OrderAggregate;

namespace Core.Specifications
{
    public class OrderByPaymentIdWithItemsSpecification : BaseSpecification<Order>
    {
        public OrderByPaymentIdWithItemsSpecification(string paymentIntendId) : base(order =>
            order.PaymentIntentId == paymentIntendId)
        {
        }
    }
}