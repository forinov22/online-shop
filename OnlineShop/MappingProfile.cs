using AutoMapper;
using OnlineShop.Models;

namespace OnlineShop;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateBrandDto, Brand>();
        CreateMap<Brand, BrandDto>();
    }
}
