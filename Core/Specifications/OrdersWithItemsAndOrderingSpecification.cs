using Core.Entities.OrderAggregate;

namespace Core.Specifications
{
    public class OrdersWithItemsAndOrderingSpecification : BaseSpecification<Order>
    {
        public OrdersWithItemsAndOrderingSpecification(string email) : base(order => order.BuyerEmail == email)
        {
            AddInclude(order => order.OrderItems);
            AddOrderByDescending(order => order.OrderDate);
        }

        public OrdersWithItemsAndOrderingSpecification(int id, string email) : base(order =>
            order.Id == id && order.BuyerEmail == email)
        {
            AddInclude(order => order.OrderItems);
        }
    }
}