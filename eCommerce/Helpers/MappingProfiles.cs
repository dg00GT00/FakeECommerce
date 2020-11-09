using AutoMapper;
using Core.Dtos;
using Core.Entities;

namespace eCommerce.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(dto => dto.ProductBrand,
                    expression => expression.MapFrom(product => product.ProductBrand.Name))
                .ForMember(dto => dto.ProductType,
                    expression => expression.MapFrom(product => product.ProductType.Name));
        }
    }
}