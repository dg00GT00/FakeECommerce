using Core.Entities;
using eCommerce.Models;

namespace eCommerce.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParamsModel productParamsModel) : base(product =>
            (!productParamsModel.BrandId.HasValue || product.ProductBrandId == productParamsModel.BrandId) &&
            (!productParamsModel.TypeId.HasValue || product.ProductTypeId == productParamsModel.TypeId)
        )
        {
            
        }
    }
}