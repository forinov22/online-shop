using Mapster;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs;

namespace OnlineShop.Models.Mappers;

public static partial class CategoryMapper
{
    private static TypeAdapterConfig TypeAdapterConfig;
        
    public static CategoryDto AdaptToDto(this Category entity)
    {
        return entity == null ? null : new CategoryDto()
        {
            Id = entity.Id,
            Name = entity.Name,
            ParentCategoryId = entity.ParentCategoryId,
            ParentCategory = TypeAdapterConfig.GetMapFunction<Category, CategoryDto>().Invoke(entity.ParentCategory)
        };
    }
    
    public static Category AdaptToCategory(this CategoryAdd dto)
    {
        return dto == null ? null : new Category()
        {
            Name = dto.Name,
            ParentCategoryId = dto.ParentCategoryId
        };
    }
}