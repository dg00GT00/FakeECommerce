using Core.Entities.OrderAggregate;

namespace Core.Specifications
{
    public class OrderWithItemsByBasketIdSpecification : BaseSpecification<Order>
    {
        public OrderWithItemsByBasketIdSpecification(string basketId) : base(order => order.BasketId == basketId)
        {
            AddInclude(order => order.OrderItems);
            AddInclude(order => order.DeliveryMethod);
            AddOrderByDescending(order => order.OrderDate);
        }
    }
}