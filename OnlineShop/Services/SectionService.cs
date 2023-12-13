using Mapster;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Exceptions;
using OnlineShop.Models.DTOs;
using OnlineShop.Models.Mappers;

namespace OnlineShop.Services;

public interface ISectionService
{
    Task<IEnumerable<SectionDto>> GetAllSectionsAsync();
    Task<SectionDto> GetSectionByIdAsync(int sectionId);
    Task<SectionDto> CreateSectionAsync(SectionAdd dto);
    Task<SectionDto> UpdateSectionAsync(int sectionId, SectionUpdate dto);
    Task<SectionDto> DeleteSectionAsync(int sectionId);
}

public class SectionService : ISectionService
{
    private readonly OnlineShopContext _context;

    public SectionService(OnlineShopContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SectionDto>> GetAllSectionsAsync()
    {
        return await _context.Sections.ProjectToType<SectionDto>().ToListAsync();
    }

    public async Task<SectionDto> GetSectionByIdAsync(int sectionId)
    {
        var section = await _context.Sections.ProjectToType<SectionDto>()
            .FirstOrDefaultAsync(s => s.Id == sectionId);

        if (section == null)
            throw new NotFoundException(ExceptionMessages.SectionNotFound);

        return section;
    }

    public async Task<SectionDto> CreateSectionAsync(SectionAdd dto)
    {
        var section = dto.AdaptToSection();
        await _context.Sections.AddAsync(section);
        await _context.SaveChangesAsync();
        return section.AdaptToDto();
    }

    public async Task<SectionDto> UpdateSectionAsync(int sectionId, SectionUpdate dto)
    {
        var existingSection = await _context.Sections.FindAsync(sectionId);

        if (existingSection == null)
            throw new NotFoundException(ExceptionMessages.ProductVersionNotFound);

        existingSection.Name = dto.Name;
        
        await _context.SaveChangesAsync();
        return existingSection.AdaptToDto();
    }

    public async Task<SectionDto> DeleteSectionAsync(int sectionId)
    {
        var existingSection = await _context.Sections.FindAsync(sectionId);

        if (existingSection == null)
            throw new NotFoundException(ExceptionMessages.ProductVersionNotFound);

        _context.Sections.Remove(existingSection);
        await _context.SaveChangesAsync();
        return existingSection.AdaptToDto();
    }
}