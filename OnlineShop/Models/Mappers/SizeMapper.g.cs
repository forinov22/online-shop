using OnlineShop.Domains;
using OnlineShop.Models.DTOs.OnlineShop.Domains;

namespace OnlineShop.Domains
{
    public static partial class SizeMapper
    {
        public static SizeDto AdaptToDto(this Size p1)
        {
            return p1 == null ? null : new SizeDto()
            {
                Id = p1.Id,
                Name = p1.Name
            };
        }
        public static SizeDto AdaptTo(this Size p2, SizeDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            SizeDto result = p3 ?? new SizeDto();
            
            result.Id = p2.Id;
            result.Name = p2.Name;
            return result;
            
        }
        public static Size AdaptToSize(this SizeAdd p4)
        {
            return p4 == null ? null : new Size() {Name = p4.Name};
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
        public static Size AdaptToSize(this SizeUpdate p7)
        {
            return p7 == null ? null : new Size() {Name = p7.Name};
        }
        public static Size AdaptTo(this SizeUpdate p8, Size p9)
        {
            if (p8 == null)
            {
                return null;
            }
            Size result = p9 ?? new Size();
            
            result.Name = p8.Name;
            return result;
            
        }
    }
}