using System;
using Core.Entities;
using Core.Enums;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(SortBy sort)
        {
            IncludeSpecification();
            switch (sort)
            {
                case SortBy.PriceAscending:
                    AddOrderBy(p => p.Price);
                    break;
                case SortBy.PriceDescending:
                    AddOrderByDescending(p => p.Price);
                    break;
                case SortBy.NameAscending:
                    AddOrderBy(product => product.Name);
                    break;
                case SortBy.NameDescending:
                    AddOrderByDescending(product => product.Name);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(sort), sort, null);
            }
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