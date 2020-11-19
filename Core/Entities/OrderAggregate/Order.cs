using System;
using System.Collections.Generic;

namespace Core.Entities.OrderAggregate
{
    public class Order : BaseEntity
    {
        // To Entity Framework requirements
        public Order()
        {
        }

        public Order(IReadOnlyList<OrderItem> orderItems, string buyerEmail, Address shipToAddress,
            DeliveryMethod deliveryMethod, decimal subtotal)
        {
            BuyerEmail = buyerEmail;
            ShipToAddress = shipToAddress;
            DeliveryMethod = deliveryMethod;
            OrderItems = orderItems;
            Subtotal = subtotal;
        }

        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public Address ShipToAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public decimal Subtotal { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public string PaymentIntentId { get; set; }

        // This method is run automatically by AutoMapper due to fact it has a "Get" fragment in its name
        // in addition of getting the "Total" name that correspond to the same name at the destination class
        public decimal GetTotal()
        {
            return Subtotal + DeliveryMethod.Price;
        }
    }
}