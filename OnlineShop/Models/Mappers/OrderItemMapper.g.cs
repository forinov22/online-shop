using Mapster;
using Mapster.Utils;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs;

namespace OnlineShop.Models.Mappers;

public static partial class OrderItemMapper
{
    private static TypeAdapterConfig TypeAdapterConfig = new();
        
    public static OrderItemDto AdaptToDto(this OrderItem entity)
    {
        return entity == null ? null : new OrderItemDto()
        {
            OrderId = entity.OrderId,
            ProductVersionId = entity.ProductVersionId,
            Quantity = entity.Quantity,
        };
    }
}