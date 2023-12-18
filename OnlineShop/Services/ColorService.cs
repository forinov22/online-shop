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
        var color = dto.AdaptToColor();
        await _context.Colors.AddAsync(color);
        await _context.SaveChangesAsync();
        var existingColor = await _context.Colors.ProjectToType<ColorDto>()
            .FirstAsync(c => c.Id == color.Id);
        return existingColor;
    }

    public async Task<ColorDto> UpdateColorAsync(int colorId, ColorUpdate dto)
    {
        var existingColor = await _context.Colors.FindAsync(colorId);

        if (existingColor == null)
            throw new NotFoundException(ExceptionMessages.ColorNotFound);


        existingColor.Name = dto.Name;

        await _context.SaveChangesAsync();
        return existingColor.AdaptToDto();
    }

    public async Task<ColorDto> DeleteColorAsync(int colorId)
    {
        var existingColor = await _context.Colors.FindAsync(colorId);

        if (existingColor == null)
            throw new NotFoundException(ExceptionMessages.ColorNotFound);


        _context.Colors.Remove(existingColor);
        await _context.SaveChangesAsync();
        return existingColor.AdaptToDto();
    }
}