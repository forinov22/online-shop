using Mapster;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Exceptions;
using OnlineShop.Models.DTOs;
using OnlineShop.Models.Mappers;

namespace OnlineShop.Services;

public interface IColorService
{
    Task<IEnumerable<ColorDto>> GetAllColorsAsync();
    Task<ColorDto> GetColorByIdAsync(int colorId);
    Task<ColorDto> CreateColorAsync(ColorAdd dto);
    Task<ColorDto> UpdateColorAsync(int colorId, ColorUpdate dto);
    Task<ColorDto> DeleteColorAsync(int colorId);
}

public class ColorService : IColorService
{
    private readonly OnlineShopContext _context;

    public ColorService(OnlineShopContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ColorDto>> GetAllColorsAsync()
    {
        return await _context.Colors.ProjectToType<ColorDto>().ToListAsync();
    }

    public async Task<ColorDto> GetColorByIdAsync(int colorId)
    {
        var color = await _context.Colors.ProjectToType<ColorDto>()
            .FirstOrDefaultAsync(c => c.Id == colorId);

        if (color == null)
            throw new NotFoundException(ExceptionMessages.ColorNotFound);

        return color;
    }

    public async Task<ColorDto> CreateColorAsync(ColorAdd dto)
    {
        var candidate = await _context.Colors.FirstOrDefaultAsync(c => c.Name == dto.Name);
        if (candidate is not null)
            throw new AlreadyExistsException(ExceptionMessages.ColorAlreadyExists);
        
        var color = dto.AdaptToColor();
        await _context.Colors.AddAsync(color);
        await _context.SaveChangesAsync();
        return color.AdaptToDto();
    }

    public async Task<ColorDto> UpdateColorAsync(int colorId, ColorUpdate dto)
    {
        var existingColor = await _context.Colors.FindAsync(colorId);
        if (existingColor == null)
            throw new NotFoundException(ExceptionMessages.ColorNotFound);

        var candidate = await _context.Colors.FirstOrDefaultAsync(c => c.Name == dto.Name);
        if (candidate is not null)
            throw new AlreadyExistsException(ExceptionMessages.ColorAlreadyExists);
        
        existingColor.Name = dto.Name;

        await _context.SaveChangesAsync();
        return existingColor.AdaptToDto();
    }

    public async Task<ColorDto> DeleteColorAsync(int colorId)
    {
        var existingColor = await _context.Colors.Include(c => c.ProductVersions)
            .FirstOrDefaultAsync(c => c.Id == colorId);
        if (existingColor == null)
            throw new NotFoundException(ExceptionMessages.ColorNotFound);
        if (existingColor.ProductVersions.Count > 0)
            throw new InvalidOperationException(ExceptionMessages.ColorHasProductVersions);

        _context.Colors.Remove(existingColor);
        await _context.SaveChangesAsync();
        return existingColor.AdaptToDto();
    }
}