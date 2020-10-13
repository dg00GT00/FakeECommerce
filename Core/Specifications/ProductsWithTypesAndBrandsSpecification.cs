using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification()
        {
            IncludeSpecification();
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(product => product.Id == id)
        {
            IncludeSpecification();
        }

        private void IncludeSpecification()
        {
            AddInclude(product => product.ProductType);
            AddInclude(product => product.ProductBrand);
        }
    }
}