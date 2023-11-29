using AutoMapper;
using OnlineShop.Models;
using OnlineShop.Models.Dto;

namespace OnlineShop;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateBrandDto, Brand>();
        CreateMap<Brand, BrandDto>();
        CreateMap<CreateColorDto, Color>();
        CreateMap<Color, ColorDto>();
        CreateMap<CreateSizeDto, Size>();
        CreateMap<Size, SizeDto>();
        
    }
}
