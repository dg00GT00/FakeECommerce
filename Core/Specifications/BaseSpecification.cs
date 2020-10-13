using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Interfaces;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; }

        public IEnumerable<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public BaseSpecification(Expression<Func<T, bool>> criteria = null)
        {
            Criteria = criteria;
        }

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            ((List<Expression<Func<T, object>>>) Includes).Add(includeExpression);
        }
    }
}