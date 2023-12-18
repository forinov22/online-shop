using Mapster;
using Mapster.Utils;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs;

namespace OnlineShop.Models.Mappers;

public static partial class AddressMapper
{
    private static TypeAdapterConfig TypeAdapterConfig = new();
        
    public static AddressDto AdaptToDto(this Address entity)
    {
        return entity == null ? null : new AddressDto()
        {
            Id = entity.Id,
            AddressString = entity.AddressString,
            UserId = entity.UserId,
            User = entity.User == null ? null : new UserDto()
            {
                Id = entity.User.Id,
                Email = entity.User.Email,
                Phone = entity.User.Phone,
                FirstName = entity.User.FirstName,
                LastName = entity.User.LastName,
                Password = entity.User.Password,
                UserType = Enum<UserType>.ToString(entity.User.UserType),
                Address = TypeAdapterConfig.GetMapFunction<Address, AddressDto>().Invoke(entity.User.Address)
            }
        };
    }
    
    public static Address AdaptToAddress(this AddressAdd dto)
    {
        return dto == null ? null : new Address()
        {
            AddressString = dto.AddressString,
            UserId = dto.UserId
        };
    }
}