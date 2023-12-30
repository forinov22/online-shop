using Mapster;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs;

namespace OnlineShop.Models.Mappers;

public static partial class MediaMapper
{
    private static TypeAdapterConfig TypeAdapterConfig = new();
        
    public static MediaDto AdaptToDto(this Media entity)
    {
        return entity == null ? null : new MediaDto()
        {
            Id = entity.Id,
            FileType = entity.FileType,
            FileName = entity.FileName,
            ProductId = entity.ProductId,
        };
    }
    
    public static Media AdaptToMedia(this MediaAdd dto)
    {
        return dto == null ? null : new Media()
        {
            ProductId = dto.ProductId
        };
    }
}