using Mapster;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs.OnlineShop.Domains;

namespace OnlineShop.Domains
{
    public static partial class CategoryMapper
    {
        private static TypeAdapterConfig TypeAdapterConfig1;
        
        public static CategoryDto AdaptToDto(this Category p1)
        {
            return p1 == null ? null : new CategoryDto()
            {
                Id = p1.Id,
                Name = p1.Name,
                ParentCategoryId = p1.ParentCategoryId,
                ParentCategory = p1.ParentCategory.AdaptToDto()
                //TypeAdapterConfig1.GetMapFunction<Category, CategoryDto>().Invoke(p1.ParentCategory)
            };
        }
        public static CategoryDto AdaptTo(this Category p2, CategoryDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            CategoryDto result = p3 ?? new CategoryDto();
            
            result.Id = p2.Id;
            result.Name = p2.Name;
            result.ParentCategoryId = p2.ParentCategoryId;
            result.ParentCategory = p2.ParentCategory.AdaptToDto();
            //TypeAdapterConfig1.GetMapToTargetFunction<Category, CategoryDto>().Invoke(p2.ParentCategory, result.ParentCategory);
            return result;
            
        }
        public static Category AdaptToCategory(this CategoryAdd p4)
        {
            return p4 == null ? null : new Category()
            {
                Name = p4.Name,
                ParentCategoryId = p4.ParentCategoryId
            };
        }
        public static Category AdaptTo(this CategoryAdd p5, Category p6)
        {
            if (p5 == null)
            {
                return null;
            }
            Category result = p6 ?? new Category();
            
            result.Name = p5.Name;
            result.ParentCategoryId = p5.ParentCategoryId;
            return result;
            
        }
        public static Category AdaptToCategory(this CategoryUpdate p7)
        {
            return p7 == null ? null : new Category()
            {
                Name = p7.Name,
                ParentCategoryId = p7.ParentCategoryId
            };
        }
        public static Category AdaptTo(this CategoryUpdate p8, Category p9)
        {
            if (p8 == null)
            {
                return null;
            }
            Category result = p9 ?? new Category();
            
            result.Name = p8.Name;
            result.ParentCategoryId = p8.ParentCategoryId;
            return result;
            
        }
    }
}