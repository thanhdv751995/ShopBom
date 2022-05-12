using AutoMapper;
using ShopBom.Colors;
using ShopBom.Customers;
using ShopBom.Orders;
using ShopBom.Products;
using ShopBom.ProductTypes;
using ShopBom.Promotions;
using ShopBom.Sizes;

namespace ShopBom
{
    public class ShopBomApplicationAutoMapperProfile : Profile
    {
        public ShopBomApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Customer, CustomerDto>();
            CreateMap<Color, ColorDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductType, ProductTypeDto>();
            CreateMap<Promotion, PromotionDto>();
            CreateMap<Size, SizeDto>();
        }
    }
}
