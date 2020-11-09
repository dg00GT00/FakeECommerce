using System.Collections.Generic;

namespace Core.Entities
{
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
        public List<BaskItem> Items { get; set; } = new List<BaskItem>();
    }
}