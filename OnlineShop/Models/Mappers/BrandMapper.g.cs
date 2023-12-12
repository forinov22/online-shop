using OnlineShop.Domains;
using OnlineShop.Models.DTOs.OnlineShop.Domains;

namespace OnlineShop.Domains
{
    public static partial class BrandMapper
    {
        public static BrandDto AdaptToDto(this Brand p1)
        {
            return p1 == null ? null : new BrandDto()
            {
                Id = p1.Id,
                Name = p1.Name
            };
        }
        public static BrandDto AdaptTo(this Brand p2, BrandDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            BrandDto result = p3 ?? new BrandDto();
            
            result.Id = p2.Id;
            result.Name = p2.Name;
            return result;
            
        }
        public static Brand AdaptToBrand(this BrandAdd p4)
        {
            return p4 == null ? null : new Brand() {Name = p4.Name};
        }
        public static Brand AdaptTo(this BrandAdd p5, Brand p6)
        {
            if (p5 == null)
            {
                return null;
            }
            Brand result = p6 ?? new Brand();
            
            result.Name = p5.Name;
            return result;
            
        }
        public static Brand AdaptToBrand(this BrandUpdate p7)
        {
            return p7 == null ? null : new Brand() {Name = p7.Name};
        }
        public static Brand AdaptTo(this BrandUpdate p8, Brand p9)
        {
            if (p8 == null)
            {
                return null;
            }
            Brand result = p9 ?? new Brand();
            
            result.Name = p8.Name;
            return result;
            
        }
    }
}