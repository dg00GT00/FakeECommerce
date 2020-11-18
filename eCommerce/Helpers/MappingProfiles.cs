using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Entities.Identity;

namespace eCommerce.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            GetFullProductSpecsMapping();
            InsertFullProductSpecsMapping();
            IdentityAddressMapping();
            BasketMapping();
        }

        /// <summary>
        /// Responsible for mapping the Product entity to a Dto which
        /// represents all references associate to a product 
        /// </summary>
        private void GetFullProductSpecsMapping()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(dto => dto.ProductBrand,
                    expression => expression.MapFrom(product => product.ProductBrand.Name))
                .ForMember(dto => dto.ProductType,
                    expression => expression.MapFrom(product => product.ProductType.Name));
        }

        /// <summary>
        /// Responsible for mapping a product that represents all product features, which
        /// was retrieve from an external source, to a Dto in charge of displaying only filtered
        /// out properties for database row insertion 
        /// </summary>
        private void InsertFullProductSpecsMapping()
        {
            CreateMap<ProductToInsertionDto, Product>();
        }

        /// <summary>
        /// Maps the user address for Identity purposes
        /// </summary>
        private void IdentityAddressMapping()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
        }

        /// <summary>
        /// Maps the basket items and customer basket items
        /// </summary>
        private void BasketMapping()
        {
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
        }
    }
}