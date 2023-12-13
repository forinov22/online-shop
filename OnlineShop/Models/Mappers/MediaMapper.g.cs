using Mapster;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs;

namespace OnlineShop.Models.Mappers;

public static partial class MediaMapper
{
    private static TypeAdapterConfig TypeAdapterConfig;
        
    public static MediaDto AdaptToDto(this Media entity)
    {
        return entity == null ? null : new MediaDto()
        {
            Id = entity.Id,
            Bytes = entity.Bytes,
            FileType = entity.FileType,
            FileName = entity.FileName,
            ProductId = entity.ProductId,
            Product = entity.Product == null ? null : new ProductDto()
            {
                Id = entity.Product.Id,
                Name = entity.Product.Name,
                Price = entity.Product.Price,
                BrandId = entity.Product.BrandId,
                CategoryId = entity.Product.CategoryId,
                AverageRating = entity.Product.AverageRating,
                Brand = entity.Product.Brand == null ? null : new BrandDto()
                {
                    Id = entity.Product.Brand.Id,
                    Name = entity.Product.Brand.Name
                },
                Category = entity.Product.Category == null ? null : new CategoryDto()
                {
                    Id = entity.Product.Category.Id,
                    Name = entity.Product.Category.Name,
                    ParentCategoryId = entity.Product.Category.ParentCategoryId,
                    ParentCategory = TypeAdapterConfig.GetMapFunction<Category, CategoryDto>().Invoke(entity.Product.Category.ParentCategory)
                }
            }
        };
    }
    
    public static Media AdaptToMedia(this MediaAdd dto)
    {
        return dto == null ? null : new Media()
        {
            Bytes = dto.Bytes,
            FileType = dto.FileType,
            FileName = dto.FileName,
            ProductId = dto.ProductId
        };
    }
}