using Mapster;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs.OnlineShop.Domains;

namespace OnlineShop.Services;

public interface IAddressService
{
    Task<AddressDto?> GetAddressByIdAsync(int addressId);
    Task<AddressDto> CreateAddressAsync(AddressAdd dto);
}

public class AddressService : IAddressService
{
    private readonly OnlineShopContext _context;

    public AddressService(OnlineShopContext context)
    {
        _context = context;
    }

    public async Task<AddressDto?> GetAddressByIdAsync(int addressId)
    {
        return await _context.Addresses.ProjectToType<AddressDto>()
            .FirstOrDefaultAsync(a => a.Id == addressId);
    }

    public async Task<AddressDto> CreateAddressAsync(AddressAdd dto)
    {
        var address = dto.AdaptToAddress();
        await _context.Addresses.AddAsync(address);
        await _context.SaveChangesAsync();
        return address.AdaptToDto();
    }
}