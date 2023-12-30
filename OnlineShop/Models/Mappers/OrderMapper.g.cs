using Mapster;
using Mapster.Utils;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs;

namespace OnlineShop.Models.Mappers;

public static partial class OrderMapper
{
    private static TypeAdapterConfig TypeAdapterConfig = new();
        
    public static OrderDto AdaptToDto(this Order entity)
    {
        return entity == null ? null : new OrderDto()
        {
            Id = entity.Id,
            Price = entity.Price,
            UserId = entity.UserId,
            AddressId = entity.AddressId,
            CreatedAt = entity.CreatedAt,
            OrderStatus = Enum<OrderStatus>.ToString(entity.OrderStatus),
        };
    }
}