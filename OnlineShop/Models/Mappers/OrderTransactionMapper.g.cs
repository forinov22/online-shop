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
            Order = entity.Order == null ? null : new OrderDto()
            {
                Id = entity.Order.Id,
                Price = entity.Order.Price,
                UserId = entity.Order.UserId,
                AddressId = entity.Order.AddressId,
                CreatedAt = entity.Order.CreatedAt,
                OrderStatus = Enum<OrderStatus>.ToString(entity.Order.OrderStatus),
                Address = entity.Order.Address == null ? null : new AddressDto()
                {
                    Id = entity.Order.Address.Id,
                    AddressString = entity.Order.Address.AddressString,
                    UserId = entity.Order.Address.UserId,
                    User = entity.Order.Address.User == null ? null : new UserDto()
                    {
                        Id = entity.Order.Address.User.Id,
                        Email = entity.Order.Address.User.Email,
                        Phone = entity.Order.Address.User.Phone,
                        FirstName = entity.Order.Address.User.FirstName,
                        LastName = entity.Order.Address.User.LastName,
                        Password = entity.Order.Address.User.Password,
                        UserType = Enum<UserType>.ToString(entity.Order.Address.User.UserType),
                        Address = TypeAdapterConfig.GetMapFunction<Address, AddressDto>().Invoke(entity.Order.Address.User.Address)
                    }
                },
                User = entity.Order.User == null ? null : new UserDto()
                {
                    Id = entity.Order.User.Id,
                    Email = entity.Order.User.Email,
                    Phone = entity.Order.User.Phone,
                    FirstName = entity.Order.User.FirstName,
                    LastName = entity.Order.User.LastName,
                    Password = entity.Order.User.Password,
                    UserType = Enum<UserType>.ToString(entity.Order.User.UserType),
                    Address = entity.Order.User.Address == null ? null : new AddressDto()
                    {
                        Id = entity.Order.User.Address.Id,
                        AddressString = entity.Order.User.Address.AddressString,
                        UserId = entity.Order.User.Address.UserId,
                        User = TypeAdapterConfig.GetMapFunction<User, UserDto>().Invoke(entity.Order.User.Address.User)
                    }
                }
            }
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