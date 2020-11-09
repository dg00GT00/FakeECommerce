using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class PostRepository<T> : IPostRepository<T> where T : Product
    {
        private readonly StoreContext _context;

        /// <summary>
        /// Repository for putting entities into a database either or not
        /// based on some specifications
        /// </summary>
        /// <param name="context">the db context to apply the operations on</param>
        public PostRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<T> InsertEntityAsync(T product)
        {
            _context.Attach(product);
            _context.Add(product);
            await _context.SaveChangesAsync();
            var insertedEntity = await _context.Set<T>()
                .AsNoTracking()
                .OrderByDescending(entity => entity.Id)
                .FirstAsync();
            return insertedEntity;
        }
    }
}