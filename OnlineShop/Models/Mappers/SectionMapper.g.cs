using OnlineShop.Domains;
using OnlineShop.Models.DTOs.OnlineShop.Domains;

namespace OnlineShop.Domains
{
    public static partial class SectionMapper
    {
        public static SectionDto AdaptToDto(this Section p1)
        {
            return p1 == null ? null : new SectionDto()
            {
                Id = p1.Id,
                Name = p1.Name
            };
        }
        public static SectionDto AdaptTo(this Section p2, SectionDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            SectionDto result = p3 ?? new SectionDto();
            
            result.Id = p2.Id;
            result.Name = p2.Name;
            return result;
            
        }
        public static Section AdaptToSection(this SectionAdd p4)
        {
            return p4 == null ? null : new Section() {Name = p4.Name};
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
        public static Section AdaptToSection(this SectionUpdate p7)
        {
            return p7 == null ? null : new Section() {Name = p7.Name};
        }
        public static Section AdaptTo(this SectionUpdate p8, Section p9)
        {
            if (p8 == null)
            {
                return null;
            }
            Section result = p9 ?? new Section();
            
            result.Name = p8.Name;
            return result;
            
        }
    }
}