using Mapster;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Exceptions;
using OnlineShop.Models.DTOs;
using OnlineShop.Models.Mappers;

namespace OnlineShop.Services;

public interface IAddressService
{
    Task<AddressDto> GetAddressByIdAsync(int addressId);
    Task<AddressDto> CreateAddressAsync(AddressAdd dto);
}

public class AddressService : IAddressService
{
    private readonly OnlineShopContext _context;

    public AddressService(OnlineShopContext context)
    {
        _context = context;
    }

    public async Task<AddressDto> GetAddressByIdAsync(int addressId)
    {
        var address = await _context.Addresses.ProjectToType<AddressDto>()
            .FirstOrDefaultAsync(a => a.Id == addressId);

        if (address == null)
            throw new NotFoundException(ExceptionMessages.AddressNotFound);

        return address;
    }

    public async Task<AddressDto> CreateAddressAsync(AddressAdd dto)
    {
        var user = await _context.Users.FindAsync(dto.UserId);
        if (user is null)
            throw new NotFoundException(ExceptionMessages.UserNotFound);

        var address = dto.AdaptToAddress();
        await _context.Addresses.AddAsync(address);
        await _context.SaveChangesAsync();
        return address.AdaptToDto();
    }
}