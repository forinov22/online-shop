using Mapster;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs;

namespace OnlineShop.Models.Mappers;

public static partial class ProductVersionMapper
{
    private static TypeAdapterConfig TypeAdapterConfig = new();
        
    public static ProductVersionDto AdaptToDto(this ProductVersion entity)
    {
        return entity == null ? null : new ProductVersionDto()
        {
            Id = entity.Id,
            Quantity = entity.Quantity,
            Sku = entity.Sku,
            ProductId = entity.ProductId,
            SizeId = entity.SizeId,
            ColorId = entity.ColorId,
        };
    }
    
    public static ProductVersion AdaptToProductVersion(this ProductVersionAdd dto)
    {
        return dto == null ? null : new ProductVersion()
        {
            Quantity = dto.Quantity,
            Sku = dto.Sku,
            ProductId = dto.ProductId,
            SizeId = dto.SizeId,
            ColorId = dto.ColorId
        };
    }
}