using OnlineShop.Domains;
using OnlineShop.Models.DTOs;

namespace OnlineShop.Models.Mappers;

public static partial class BrandMapper
{
    public static BrandDto AdaptToDto(this Brand entity)
    {
        return entity == null ? null : new BrandDto()
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }
    
    public static Brand AdaptToBrand(this BrandAdd dto)
    {
        return dto == null ? null : new Brand() {Name = dto.Name};
    }
}