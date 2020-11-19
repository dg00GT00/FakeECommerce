using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Address = Core.Entities.Identity.Address;

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
            OrderMapping();
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
        /// Maps the user address for Identity and Order aggregate
        /// </summary>
        private void IdentityAddressMapping()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<AddressDto, Core.Entities.OrderAggregate.Address>();
        }

        /// <summary>
        /// Maps the basket items and customer basket items
        /// </summary>
        private void BasketMapping()
        {
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
        }

        /// <summary>
        /// Maps for ordering items
        /// </summary>
        private void OrderMapping()
        {
            CreateMap<Order, OrderToReturnDto>()
                .ForMember(dto => dto.DeliveryMethod,
                    expression => expression.MapFrom(order => order.DeliveryMethod.ShortName))
                .ForMember(dto => dto.ShippingPrice,
                    expression => expression.MapFrom(order => order.DeliveryMethod.Price));
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dto => dto.ProductId,
                    expression => expression.MapFrom(item => item.ItemOrdered.ProductItemId))
                .ForMember(dto => dto.ProductName,
                    expression => expression.MapFrom(item => item.ItemOrdered.ProductName))
                .ForMember(dto => dto.PictureUrl,
                    expression => expression.MapFrom(item => item.ItemOrdered.PictureUrl));
        }
    }
}