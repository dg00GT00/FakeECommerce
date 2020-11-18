using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.OrderAggregate
{
    [Table("OrderItem", Schema = "Dev")]
    public class OrderItem : BaseEntity
    {
        // To Entity Framework requirements
        public OrderItem()
        {
        }

        // Obs: Populating the properties through constructor is optional
        // when instantiating a new class
        public OrderItem(ProductItemOrdered itemOrdered, decimal price, int quantity)
        {
            ItemOrdered = itemOrdered;
            Price = price;
            Quantity = quantity;
        }

        public ProductItemOrdered ItemOrdered { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}