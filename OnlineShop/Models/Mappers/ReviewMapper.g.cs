using Mapster;
using Mapster.Utils;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs;

namespace OnlineShop.Models.Mappers;

public static partial class ReviewMapper
{
    private static TypeAdapterConfig TypeAdapterConfig = new();
        
    public static ReviewDto AdaptToDto(this Review entity)
    {
        return entity == null ? null : new ReviewDto()
        {
            Id = entity.Id,
            Rating = entity.Rating,
            Comment = entity.Comment,
            ProductId = entity.ProductId,
            UserId = entity.UserId,
            Title = entity.Title,
            CreatedAt = entity.CreatedAt,
        };
    }
    
    public static Review AdaptToReview(this ReviewAdd dto)
    {
        return dto == null ? null : new Review()
        {
            Rating = dto.Rating,
            Comment = dto.Comment,
            ProductId = dto.ProductId,
            UserId = dto.UserId,
            Title = dto.Title,
            CreatedAt = dto.CreatedAt
        };
    }
}