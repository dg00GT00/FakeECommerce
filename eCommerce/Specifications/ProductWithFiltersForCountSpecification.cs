using Core.Entities;
using eCommerce.Models;

namespace eCommerce.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParamsModel productParamsModel) : base(product =>
            (string.IsNullOrEmpty(productParamsModel.Search) || product.Name.ToLower().Contains(productParamsModel.Search)) &&
            (!productParamsModel.BrandId.HasValue || product.ProductBrandId == productParamsModel.BrandId) &&
            (!productParamsModel.TypeId.HasValue || product.ProductTypeId == productParamsModel.TypeId)
        )
        {
            
        }
    }
}