using DbFirstApp.Data;
using OnlineShop.Models;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Services;

public interface ICategoryService {
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category?> GetCategoryByIdAsync(int id);
    Task<Category> CreateCategoryAsync(Category category);
    Task<Category?> UpdateCategoryAsync(int id, Category updatedCategory);
    Task<bool> DeleteCategoryAsync(int id);
};

public class CategoryService : ICategoryService
{
    private readonly OnlineShopContext _ctx;

    public CategoryService(OnlineShopContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<Category> CreateCategoryAsync(Category category)
    {
        await _ctx.Categories.AddAsync(category);
        await _ctx.SaveChangesAsync();
        return category;
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        var existingCategory = await _ctx.Categories.FindAsync(id);

        if (existingCategory == null) 
            return false;

        _ctx.Categories.Remove(existingCategory);
        await _ctx.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await _ctx.Categories.ToListAsync();
    }

    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
        return await _ctx.Categories.FindAsync(id);
    }

    public async Task<Category?> UpdateCategoryAsync(int id, Category updatedCategory)
    {
        var category = await _ctx.Categories.FindAsync(id);

        if (category != null) {
            category.Name = updatedCategory.Name;
            category.ParentCategoryId = updatedCategory.ParentCategoryId;
            await _ctx.SaveChangesAsync();
        }

        return category;
    }
}
