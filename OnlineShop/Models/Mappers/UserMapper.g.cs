using Mapster;
using Mapster.Utils;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs;

namespace OnlineShop.Models.Mappers;

public static partial class UserMapper
{
    private static TypeAdapterConfig TypeAdapterConfig = new();
        
    public static UserDto AdaptToDto(this User entity)
    {
        return entity == null ? null : new UserDto()
        {
            Id = entity.Id,
            Email = entity.Email,
            Phone = entity.Phone,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Password = entity.Password,
            UserType = Enum<UserType>.ToString(entity.UserType),
            Address = entity.Address == null ? null : new AddressDto()
            {
                Id = entity.Address.Id,
                AddressString = entity.Address.AddressString,
                UserId = entity.Address.UserId,
                User = TypeAdapterConfig.GetMapFunction<User, UserDto>().Invoke(entity.Address.User)
            }
        };
    }
    
    public static User AdaptToUser(this UserAdd dto)
    {
        return dto == null ? null : new User()
        {
            Email = dto.Email,
            Phone = dto.Phone,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Password = dto.Password,
            UserType = dto.UserType == null ? UserType.Admin : Enum<UserType>.Parse(dto.UserType)
        };
    }
}