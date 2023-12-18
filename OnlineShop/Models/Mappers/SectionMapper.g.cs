using OnlineShop.Domains;
using OnlineShop.Models.DTOs;

namespace OnlineShop.Models.Mappers;

public static partial class SectionMapper
{
    public static SectionDto AdaptToDto(this Section entity)
    {
        return entity == null ? null : new SectionDto()
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }
    
    public static Section AdaptToSection(this SectionAdd dto)
    {
        return dto == null ? null : new Section() {Name = dto.Name};
    }
    public static Section AdaptTo(this SectionAdd p5, Section p6)
    {
        if (p5 == null)
        {
            return null;
        }
        Section result = p6 ?? new Section();
            
        result.Name = p5.Name;
        return result;
            
    }
}