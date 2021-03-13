using System.Collections.Generic;

namespace Core.Entities
{
    /// <summary>
    /// Redis related entity
    /// </summary>
    public class CustomerBasket
    {
        public int Id { get; set; }
        public string? UserEmail { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
        public int? DeliveryMethodId { get; set; }
        public string? ClientSecret { get; set; }
        public string? PaymentIntentId { get; set; }

        public decimal ShippingPrice { get; set; }
    }
}