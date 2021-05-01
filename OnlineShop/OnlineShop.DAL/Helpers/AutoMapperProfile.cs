using AutoMapper;
using OnlineShop.Models;
using OnlineShop.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.DAL.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<City, CityDTO>().ReverseMap();
            CreateMap<ShoesSize, ShoeSizesDto>().ReverseMap();
            CreateMap<SubCategory, SubCategoryDTO>().ReverseMap();
            CreateMap<GenderCategory, GenderCategoryDTO>().ReverseMap();
            CreateMap<Color, ColorDTO>().ReverseMap();
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<ClothesSize, ClothesSizeDTO>().ReverseMap();

            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.Color.Name))
                .ForMember(dest => dest.GenderName, opt => opt.MapFrom(src => src.GenderCategory.Name))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.SubCategory.CategoryId))
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.Name));
            CreateMap<ProductDTO, Product>();


            CreateMap<ShoppingCartItem, ShoppingCartItemDTO>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.UserAccount.Username))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.SubCategory, opt => opt.MapFrom(src => src.Product.SubCategory.Name))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Product.Color.Name))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Product.SubCategory.CategoryId))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Product.ImageUrl));
            CreateMap<ShoppingCartItemDTO, ShoppingCartItem>();

            CreateMap<OrderDTO, Order>().ReverseMap();
            CreateMap<OrderProduct, OrderProductDTO>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Product.ImageUrl))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));
            CreateMap<OrderProductDTO, OrderProduct>();
            CreateMap<Transaction, TransactionDTO>().ReverseMap();

        }
    }
}
