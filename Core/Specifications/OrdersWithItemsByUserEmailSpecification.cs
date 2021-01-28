using Core.Entities.OrderAggregate;

namespace Core.Specifications
{
    public class OrdersWithItemsByUserEmailSpecification : BaseSpecification<Order>
    {
        public OrdersWithItemsByUserEmailSpecification(string buyerEmail) : base(
            order => order.BuyerEmail == buyerEmail)
        {
            AddInclude(order => order.OrderItems);
            AddInclude(order => order.DeliveryMethod);
            AddOrderByDescending(order => order.OrderDate);
        }

        public OrdersWithItemsByUserEmailSpecification(int id, string buyerEmail) : base(order =>
            order.Id == id && order.BuyerEmail == buyerEmail)
        {
            AddInclude(order => order.OrderItems);
            AddInclude(order => order.DeliveryMethod);
        }
    }
}