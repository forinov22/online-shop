using Mapster;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs;

namespace OnlineShop.Models.Mappers;

public static partial class ProductMapper
{
    private static TypeAdapterConfig TypeAdapterConfig;
        
    public static ProductDto AdaptToDto(this Product entity)
    {
        return entity == null ? null : new ProductDto()
        {
            Id = entity.Id,
            Name = entity.Name,
            Price = entity.Price,
            BrandId = entity.BrandId,
            CategoryId = entity.CategoryId,
            AverageRating = entity.AverageRating,
            Brand = entity.Brand == null ? null : new BrandDto()
            {
                Id = entity.Brand.Id,
                Name = entity.Brand.Name
            },
            Category = entity.Category == null ? null : new CategoryDto()
            {
                Id = entity.Category.Id,
                Name = entity.Category.Name,
                ParentCategoryId = entity.Category.ParentCategoryId,
                ParentCategory = TypeAdapterConfig.GetMapFunction<Category, CategoryDto>().Invoke(entity.Category.ParentCategory)
            }
        };
    }
    
    public static Product AdaptToProduct(this ProductAdd dto)
    {
        return dto == null ? null : new Product()
        {
            Name = dto.Name,
            Price = dto.Price,
            BrandId = dto.BrandId,
            CategoryId = dto.CategoryId,
            AverageRating = dto.AverageRating
        };
    }
}