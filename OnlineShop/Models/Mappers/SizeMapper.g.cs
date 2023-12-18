using OnlineShop.Domains;
using OnlineShop.Models.DTOs;

namespace OnlineShop.Models.Mappers;

public static partial class SizeMapper
{
    public static SizeDto AdaptToDto(this Size entity)
    {
        return entity == null ? null : new SizeDto()
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }
    
    public static Size AdaptToSize(this SizeAdd dto)
    {
        return dto == null ? null : new Size() {Name = dto.Name};
    }
    public static Size AdaptTo(this SizeAdd p5, Size p6)
    {
        if (p5 == null)
        {
            return null;
        }
        Size result = p6 ?? new Size();
            
        result.Name = p5.Name;
        return result;
            
    }
}