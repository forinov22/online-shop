using Mapster;
using Mapster.Utils;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs;

namespace OnlineShop.Models.Mappers;

public static partial class OrderTransactionMapper
{
    private static TypeAdapterConfig TypeAdapterConfig = new();
        
    public static OrderTransactionDto AdaptToDto(this OrderTransaction entity)
    {
        return entity == null ? null : new OrderTransactionDto()
        {
            Id = entity.Id,
            UpdatedAt = entity.UpdatedAt,
            OrderTransactionStatus = Enum<OrderStatus>.ToString(entity.OrderTransactionStatus),
            OrderId = entity.OrderId,
        };
    }
    
    public static OrderTransaction AdaptToOrderTransaction(this OrderTransactionAdd dto)
    {
        return dto == null ? null : new OrderTransaction()
        {
            UpdatedAt = dto.UpdatedAt,
            OrderTransactionStatus = dto.OrderTransactionStatus == null ? OrderStatus.Processing : Enum<OrderStatus>.Parse(dto.OrderTransactionStatus),
            OrderId = dto.OrderId
        };
    }
}