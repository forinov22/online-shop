using Mapster;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs.OnlineShop.Domains;

namespace OnlineShop.Services;

public interface IColorService
{
    Task<IEnumerable<ColorDto>> GetAllColorsAsync();
    Task<ColorDto?> GetColorByIdAsync(int colorId);
    Task<ColorDto> CreateColorAsync(ColorAdd dto);
    Task<ColorDto?> UpdateColorAsync(int colorId, ColorUpdate dto);
    Task<bool> DeleteColorAsync(int colorId);
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

    public async Task<ColorDto?> GetColorByIdAsync(int colorId)
    {
        var color = await _context.Colors.FindAsync(colorId);
        return color?.AdaptToDto();
    }

    public async Task<ColorDto> CreateColorAsync(ColorAdd dto)
    {
        var color = dto.AdaptToColor();
        await _context.Colors.AddAsync(color);
        await _context.SaveChangesAsync();
        return color.AdaptToDto();
    }

    public async Task<ColorDto?> UpdateColorAsync(int colorId, ColorUpdate dto)
    {
        var existingColor = await _context.Colors.FindAsync(colorId);

        if (existingColor == null)
            return null;

        existingColor.Name = dto.Name;

        await _context.SaveChangesAsync();
        return existingColor.AdaptToDto();
    }

    public async Task<bool> DeleteColorAsync(int colorId)
    {
        var existingColor = await _context.Colors.FindAsync(colorId);

        if (existingColor == null)
            return false;

        _context.Colors.Remove(existingColor);
        await _context.SaveChangesAsync();
        return true;
    }
}