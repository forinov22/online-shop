using Mapster;
using Mapster.Utils;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs.OnlineShop.Domains;

namespace OnlineShop.Domains;

public static partial class AddressMapper
{
    private static TypeAdapterConfig TypeAdapterConfig1;
        
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
                Address = TypeAdapterConfig1.GetMapFunction<Address, AddressDto>().Invoke(entity.User.Address)
            }
        };
    }
    public static AddressDto AdaptTo(this Address entity, AddressDto dto)
    {
        if (entity == null)
        {
            return null;
        }
        AddressDto result = dto ?? new AddressDto();
            
        result.Id = entity.Id;
        result.AddressString = entity.AddressString;
        result.UserId = entity.UserId;
        result.User = entity.User.AdaptToDto();
        return result;
            
    }
    public static Address AdaptToAddress(this AddressAdd dto)
    {
        return dto == null ? null : new Address()
        {
            AddressString = dto.AddressString,
            UserId = dto.UserId
        };
    }
    public static Address AdaptTo(this AddressAdd dto, Address entity)
    {
        if (dto == null)
        {
            return null;
        }
        Address result = entity ?? new Address();
            
        result.AddressString = dto.AddressString;
        result.UserId = dto.UserId;
        return result;
            
    }
    public static Address AdaptToAddress(this AddressUpdate dto)
    {
        return dto == null ? null : new Address()
        {
            AddressString = dto.AddressString,
            UserId = dto.UserId
        };
    }
    public static Address AdaptTo(this AddressUpdate dto, Address entity)
    {
        if (dto == null)
        {
            return null;
        }
        Address result = entity ?? new Address();
            
        result.AddressString = dto.AddressString;
        result.UserId = dto.UserId;
        return result;
            
    }
}