using Mapster;
using Mapster.Utils;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs;

namespace OnlineShop.Models.Mappers;

public static partial class CartItemMapper
{
    private static TypeAdapterConfig TypeAdapterConfig = new();

    public static CartItemDto AdaptToDto(this CartItem entity)
    {
        return entity == null
            ? null
            : new CartItemDto()
            {
                UserId = entity.UserId,
                ProductVersionId = entity.ProductVersionId,
                Quantity = entity.Quantity,
            };
    }

    public static CartItem AdaptToCartItem(this CartItemAdd dto)
    {
        return dto == null
            ? null
            : new CartItem()
            {
                ProductVersionId = dto.ProductVersionId,
                Quantity = dto.Quantity
            };
    }
}