using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SqlServerBasketRepository : IBasketRepository
    {
        private readonly StoreContext _context;

        public SqlServerBasketRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<CustomerBasket?> GetBasketAsync(string basketId)
        {
            return await _context.Basket?
                .Include(basket => basket.Items)
                .AsNoTracking()
                .FirstOrDefaultAsync(basket => basket.UserEmail == basketId);
        }

        public async Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket newBasket)
        {
            var currentBasket = await GetBasketAsync(newBasket.UserEmail);

            if (currentBasket != null)
            {
                _context.Basket?.Update(currentBasket);
                currentBasket.Items = newBasket.Items;
                currentBasket.DeliveryMethodId = newBasket.DeliveryMethodId;
                currentBasket.ShippingPrice = newBasket.ShippingPrice;
                currentBasket.PaymentIntentId = newBasket.PaymentIntentId;
                currentBasket.ClientSecret = newBasket.ClientSecret;
            }
            else
            {
                _context.Basket?.Add(newBasket);
            }

            await _context.SaveChangesAsync();
            return await GetBasketAsync(newBasket.UserEmail);
        }

        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            var basket = await GetBasketAsync(basketId);
            if (basket == null) return false;
            _context.Basket?.Remove(basket);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}