using System;
using System.Linq.Expressions;
using Core.Entities;
using Core.Models;

namespace Core.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParamsModel productParamsModel)
        {
            Criteria = BaseCriteria(productParamsModel);
        }

        private static Expression<Func<Product, bool>> BaseCriteria(ProductSpecParamsModel productParamsModel)
        {
            return product =>
                product.Name != null && (string.IsNullOrEmpty(productParamsModel.Search) ||
                                         product.Name.ToLower().Contains(productParamsModel.Search)) &&
                (!productParamsModel.BrandId.HasValue || product.ProductBrandId == productParamsModel.BrandId) &&
                (!productParamsModel.TypeId.HasValue || product.ProductTypeId == productParamsModel.TypeId);
        }
    }
}