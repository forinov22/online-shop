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