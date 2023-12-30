using Mapster;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs;

namespace OnlineShop.Models.Mappers;

public static partial class ProductMapper
{
    private static TypeAdapterConfig TypeAdapterConfig = new();
        
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
        };
    }
    
    public static Product AdaptToProduct(this ProductAdd dto)
    {
        return dto == null ? null : new Product()
        {
            Name = dto.Name,
            Price = dto.Price,
            BrandId = dto.BrandId,
            CategoryId = dto.CategoryId
        };
    }
}