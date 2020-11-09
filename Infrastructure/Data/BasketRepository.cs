using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class BasketRepository : IBasketRepository
    {
        public async Task<CustomerBasket> GetBasketAsync(string basketId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            throw new System.NotImplementedException();
        }
    }
}