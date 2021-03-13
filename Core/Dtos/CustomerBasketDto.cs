using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    public class CustomerBasketDto
    {
        public int Id { get; set; }
        public List<BasketItemDto>? Items { get; set; }
        [Required] public string? UserEmail { get; set; }
        public int? DeliveryMethodId { get; set; }
        public string? ClientSecret { get; set; }
        public string? PaymentIntentId { get; set; }
        public decimal ShippingPrice { get; set; }
    }
}