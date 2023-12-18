using OnlineShop.Domains;
using OnlineShop.Models.DTOs;

namespace OnlineShop.Models.Mappers;

public static partial class ColorMapper
{
    public static ColorDto AdaptToDto(this Color entity)
    {
        return entity == null ? null : new ColorDto()
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }
    
    public static Color AdaptToColor(this ColorAdd dto)
    {
        return dto == null ? null : new Color() {Name = dto.Name};
    }
}