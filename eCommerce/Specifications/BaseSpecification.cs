using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Interfaces;

namespace eCommerce.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public int Take { get; private set; }
        
        public int Skip { get; private set; }
        
        public bool IsPagingEnabled { get; private set; }
        public Expression<Func<T, bool>> Criteria { get; protected set; }

        public IEnumerable<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public BaseSpecification(Expression<Func<T, bool>> criteria = null)
        {
            Criteria = criteria;
        }

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            ((List<Expression<Func<T, object>>>) Includes).Add(includeExpression);
        }

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }
        
        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }

        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
    }
}