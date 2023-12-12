using OnlineShop.Domains;
using OnlineShop.Models.DTOs.OnlineShop.Domains;

namespace OnlineShop.Domains
{
    public static partial class ColorMapper
    {
        public static ColorDto AdaptToDto(this Color p1)
        {
            return p1 == null ? null : new ColorDto()
            {
                Id = p1.Id,
                Name = p1.Name
            };
        }
        public static ColorDto AdaptTo(this Color p2, ColorDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            ColorDto result = p3 ?? new ColorDto();
            
            result.Id = p2.Id;
            result.Name = p2.Name;
            return result;
            
        }
        public static Color AdaptToColor(this ColorAdd p4)
        {
            return p4 == null ? null : new Color() {Name = p4.Name};
        }
        public static Color AdaptTo(this ColorAdd p5, Color p6)
        {
            if (p5 == null)
            {
                return null;
            }
            Color result = p6 ?? new Color();
            
            result.Name = p5.Name;
            return result;
            
        }
        public static Color AdaptToColor(this ColorUpdate p7)
        {
            return p7 == null ? null : new Color() {Name = p7.Name};
        }
        public static Color AdaptTo(this ColorUpdate p8, Color p9)
        {
            if (p8 == null)
            {
                return null;
            }
            Color result = p9 ?? new Color();
            
            result.Name = p8.Name;
            return result;
            
        }
    }
}