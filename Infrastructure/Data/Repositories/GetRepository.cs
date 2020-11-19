using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class GetRepository<T> : IGetRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;

        /// <summary>
        /// Repository for getting entities from the database either or not
        /// based on some specifications
        /// </summary>
        /// <param name="context">the db context to apply the operations on</param>
        public GetRepository(StoreContext context)
        {
            _context = context;
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecEvaluator<T>.QueryBuilder(_context.Set<T>().AsQueryable(), spec);
        }

        public async Task<T> GetEntityByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllEntitiesAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListEntityAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<int> CountEntityAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }
    }
}