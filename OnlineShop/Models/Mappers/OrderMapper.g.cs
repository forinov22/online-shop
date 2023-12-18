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
            Address = entity.Address == null ? null : new AddressDto()
            {
                Id = entity.Address.Id,
                AddressString = entity.Address.AddressString,
                UserId = entity.Address.UserId,
                User = entity.Address.User == null ? null : new UserDto()
                {
                    Id = entity.Address.User.Id,
                    Email = entity.Address.User.Email,
                    Phone = entity.Address.User.Phone,
                    FirstName = entity.Address.User.FirstName,
                    LastName = entity.Address.User.LastName,
                    Password = entity.Address.User.Password,
                    UserType = Enum<UserType>.ToString(entity.Address.User.UserType),
                    Address = TypeAdapterConfig.GetMapFunction<Address, AddressDto>().Invoke(entity.Address.User.Address)
                }
            },
            User = entity.User == null ? null : new UserDto()
            {
                Id = entity.User.Id,
                Email = entity.User.Email,
                Phone = entity.User.Phone,
                FirstName = entity.User.FirstName,
                LastName = entity.User.LastName,
                Password = entity.User.Password,
                UserType = Enum<UserType>.ToString(entity.User.UserType),
                Address = entity.User.Address == null ? null : new AddressDto()
                {
                    Id = entity.User.Address.Id,
                    AddressString = entity.User.Address.AddressString,
                    UserId = entity.User.Address.UserId,
                    User = TypeAdapterConfig.GetMapFunction<User, UserDto>().Invoke(entity.User.Address.User)
                }
            }
        };
    }
}