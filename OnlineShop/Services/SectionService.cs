using DbFirstApp.Data;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;

namespace OnlineShop.Services;

public interface ISectionService {
    Task<IEnumerable<Section>> GetAllSectionsAsync();
    Task<Section?> GetSectionByIdAsync(int id);
    Task<Section> CreateSectionAsync(Section section);
    Task<Section?> UpdateSectionAsync(int id, Section updatedSection);
}

public class SectionService : ISectionService
{
    private readonly OnlineShopContext context;

    public SectionService(OnlineShopContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Section>> GetAllSectionsAsync() {
        var sections = await context.Sections.ToListAsync();
        return sections;
    }

    public async Task<Section?> GetSectionByIdAsync(int id) {
        var section = await context.Sections.FindAsync(id);
        return section;
    }

    public async Task<Section> CreateSectionAsync(Section section) {
        await context.Sections.AddAsync(section);
        await context.SaveChangesAsync();
        return section;
    }

    public async Task<Section?> UpdateSectionAsync(int id, Section updatedSection) {
        var existingSection = await context.Sections.FindAsync(id);

        if (existingSection == null)
            return null;

        existingSection.Name = updatedSection.Name;
        await context.SaveChangesAsync();

        return existingSection;
    }
}
