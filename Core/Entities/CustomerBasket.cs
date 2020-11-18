using System.Collections.Generic;

namespace Core.Entities
{
    /// <summary>
    /// Redis related entity
    /// </summary>
    public class CustomerBasket
    {
        // Empty constructor for Redis purposes
        public CustomerBasket()
        {
        }

        public CustomerBasket(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    }
}