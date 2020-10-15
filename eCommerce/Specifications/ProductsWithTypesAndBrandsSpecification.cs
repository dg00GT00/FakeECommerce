using System;
using System.Linq.Expressions;
using Core.Entities;
using Core.Enums;
using eCommerce.Models;

namespace eCommerce.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParamsModel productParamsModel)
        {
            Criteria = BaseCriteria(productParamsModel);
            IncludeSpecification();
            ApplyPaging(productParamsModel.PageSize * (productParamsModel.PageIndex - 1), productParamsModel.PageSize);
            var sortSortProperty = productParamsModel.Sort;
            switch (sortSortProperty)
            {
                case SortBy.PriceAsc:
                    AddOrderBy(p => p.Price);
                    break;
                case SortBy.PriceDesc:
                    AddOrderByDescending(p => p.Price);
                    break;
                case SortBy.NameAsc:
                    AddOrderBy(product => product.Name);
                    break;
                case SortBy.NameDesc:
                    AddOrderByDescending(product => product.Name);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(sortSortProperty), sortSortProperty, null);
            }
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(product => product.Id == id)
        {
            IncludeSpecification();
        }

        private static Expression<Func<Product, bool>> BaseCriteria(ProductSpecParamsModel productParamsModel)
        {
            return product =>
                (string.IsNullOrEmpty(productParamsModel.Search) ||
                 product.Name.ToLower().Contains(productParamsModel.Search)) &&
                (!productParamsModel.BrandId.HasValue || product.ProductBrandId == productParamsModel.BrandId) &&
                (!productParamsModel.TypeId.HasValue || product.ProductTypeId == productParamsModel.TypeId);
        }
        
        private void IncludeSpecification()
        {
            AddInclude(product => product.ProductType);
            AddInclude(product => product.ProductBrand);
        }
    }
}