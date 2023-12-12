using Mapster;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs.OnlineShop.Domains;

namespace OnlineShop.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
    Task<CategoryDto?> GetCategoryByIdAsync(int categoryId);
    Task<CategoryDto> CreateCategoryAsync(CategoryAdd dto);
    Task<CategoryDto?> UpdateCategoryAsync(int categoryId, CategoryUpdate dto);
    Task<bool> DeleteCategoryAsync(int categoryId);
}

public class CategoryService : ICategoryService
{
    private readonly OnlineShopContext _context;

    public CategoryService(OnlineShopContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
    {
        return await _context.Categories.ProjectToType<CategoryDto>().ToListAsync();
    }

    public async Task<CategoryDto?> GetCategoryByIdAsync(int categoryId)
    {
        return await _context.Categories.ProjectToType<CategoryDto>()
            .FirstOrDefaultAsync(c => c.Id == categoryId);
    }

    public async Task<CategoryDto> CreateCategoryAsync(CategoryAdd dto)
    {
        var category = dto.AdaptToCategory();
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        var existingCategory = await _context.Categories.ProjectToType<CategoryDto>()
            .FirstAsync(c => c.Id == category.Id);
        return existingCategory;
    }

    public async Task<CategoryDto?> UpdateCategoryAsync(int categoryId, CategoryUpdate dto)
    {
        var existingCategory = await _context.Categories
            .FirstOrDefaultAsync(c => c.Id == categoryId);

        if (existingCategory == null)
            return null;

        existingCategory.Name = dto.Name;
        existingCategory.ParentCategoryId = dto?.ParentCategoryId;
        
        await _context.SaveChangesAsync();
        return existingCategory.AdaptToDto();
    }

    public async Task<bool> DeleteCategoryAsync(int categoryId)
    {
        var existingCategory = await _context.Categories.FindAsync(categoryId);

        if (existingCategory == null)
            return false;

        _context.Categories.Remove(existingCategory);
        await _context.SaveChangesAsync();
        return true;
    }
}