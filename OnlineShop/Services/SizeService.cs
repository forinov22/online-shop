using Mapster;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Exceptions;
using OnlineShop.Models.DTOs;
using OnlineShop.Models.Mappers;

namespace OnlineShop.Services;

public interface ISizeService
{
    Task<IEnumerable<SizeDto>> GetAllSizesAsync();
    Task<SizeDto> GetSizeByIdAsync(int sizeId);
    Task<SizeDto> CreateSizeAsync(SizeAdd dto);
    Task<SizeDto> UpdateSizeAsync(int sizeId, SizeUpdate dto);
    Task<SizeDto> DeleteSizeAsync(int sizeId);
}

public class SizeService : ISizeService
{
    private readonly OnlineShopContext _context;

    public SizeService(OnlineShopContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SizeDto>> GetAllSizesAsync()
    {
        return await _context.Sizes.ProjectToType<SizeDto>().ToListAsync();
    }

    public async Task<SizeDto> GetSizeByIdAsync(int sizeId)
    {
        var size = await _context.Sizes.ProjectToType<SizeDto>()
            .FirstOrDefaultAsync(s => s.Id == sizeId);

        if (size == null)
            throw new NotFoundException(ExceptionMessages.SizeNotFound);

        return size;
    }

    public async Task<SizeDto> CreateSizeAsync(SizeAdd dto)
    {
        var size = dto.AdaptToSize();
        await _context.Sizes.AddAsync(size);
        await _context.SaveChangesAsync();
        return size.AdaptToDto();
    }

    public async Task<SizeDto> UpdateSizeAsync(int sizeId, SizeUpdate dto)
    {
        var existingSize = await _context.Sizes.FindAsync(sizeId);

        if (existingSize == null)
            throw new NotFoundException(ExceptionMessages.ProductVersionNotFound);

        existingSize.Name = dto.Name;

        await _context.SaveChangesAsync();
        return existingSize.AdaptToDto();
    }

    public async Task<SizeDto> DeleteSizeAsync(int sizeId)
    {
        var existingSize = await _context.Sizes.FindAsync(sizeId);

        if (existingSize == null)
            throw new NotFoundException(ExceptionMessages.ProductVersionNotFound);

        _context.Sizes.Remove(existingSize);
        await _context.SaveChangesAsync();
        return existingSize.AdaptToDto();
    }
}