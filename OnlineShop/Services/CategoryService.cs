using Mapster;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Exceptions;
using OnlineShop.Models.DTOs;
using OnlineShop.Models.Mappers;

namespace OnlineShop.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
    Task<CategoryDto> GetCategoryByIdAsync(int categoryId);
    Task<CategoryDto> CreateCategoryAsync(CategoryAdd dto);
    Task<CategoryDto> UpdateCategoryNameAsync(int categoryId, CategoryUpdate dto);
    Task<CategoryDto> AddCategoryToSectionAsync(int categoryId, int sectionId);
    Task<CategoryDto> RemoveCategoryFromSectionAsync(int categoryId, int sectionId);
    Task<CategoryDto> DeleteCategoryAsync(int categoryId);
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

    public async Task<CategoryDto> GetCategoryByIdAsync(int categoryId)
    {
        var category = await _context.Categories.ProjectToType<CategoryDto>()
            .FirstOrDefaultAsync(c => c.Id == categoryId);

        if (category == null)
            throw new NotFoundException(ExceptionMessages.CategoryNotFound);

        return category;
    }

    public async Task<CategoryDto> CreateCategoryAsync(CategoryAdd dto)
    {
        var candidate = await _context.Categories.FirstOrDefaultAsync(c => c.Name == dto.Name);
        if (candidate is not null)
            throw new AlreadyExistsException(ExceptionMessages.CategoryAlreadyExists);

        if (dto.ParentCategoryId is not null)
        {
            var parent = await _context.Categories.FindAsync(dto.ParentCategoryId);
            if (parent is null)
                throw new NotFoundException(ExceptionMessages.CategoryNotFound);
        }
        
        var category = dto.AdaptToCategory();
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return category.AdaptToDto();
    }

    public async Task<CategoryDto> UpdateCategoryNameAsync(int categoryId, CategoryUpdate dto)
    {
        var existingCategory = await _context.Categories
            .FirstOrDefaultAsync(c => c.Id == categoryId);

        if (existingCategory == null)
            throw new NotFoundException(ExceptionMessages.CategoryNotFound);

        var candidate = await _context.Categories.FirstOrDefaultAsync(c => c.Name == dto.Name);
        if (candidate is not null)
            throw new AlreadyExistsException(ExceptionMessages.CategoryAlreadyExists);
        
        existingCategory.Name = dto.Name;
        
        await _context.SaveChangesAsync();
        return existingCategory.AdaptToDto();
    }

    public async Task<CategoryDto> DeleteCategoryAsync(int categoryId)
    {
        var existingCategory = await _context.Categories.Include(c => c.Products)
            .FirstOrDefaultAsync(c => c.Id == categoryId);

        if (existingCategory == null)
            throw new NotFoundException(ExceptionMessages.CategoryNotFound);

        if (existingCategory.Products.Count > 0)
            throw new InvalidOperationException(ExceptionMessages.CategoryHasProducts);

        _context.Categories.Remove(existingCategory);
        await _context.SaveChangesAsync();
        return existingCategory.AdaptToDto();
    }

    public async Task<CategoryDto> AddCategoryToSectionAsync(int categoryId, int sectionId)
    {
        var category = await _context.Categories.Include(c => c.Sections)
            .FirstOrDefaultAsync(c => c.Id == categoryId);
        if (category is null)
            throw new NotFoundException(ExceptionMessages.CategoryNotFound);

        var section = await _context.Sections.FindAsync(sectionId);
        if (section is null)
            throw new NotFoundException(ExceptionMessages.SectionNotFound);
        

        if (category.Sections.Contains(section))
            throw new AlreadyExistsException(ExceptionMessages.SectionCategoryAlreadyExists);

        category.Sections.Add(section);
        await _context.SaveChangesAsync();
        return category.AdaptToDto();
    }

    public async Task<CategoryDto> RemoveCategoryFromSectionAsync(int categoryId, int sectionId)
    {
        var category = await _context.Categories.Include(c => c.Sections)
            .FirstOrDefaultAsync(c => c.Id == categoryId);
        if (category is null)
            throw new NotFoundException(ExceptionMessages.CategoryNotFound);

        var section = await _context.Sections.FindAsync(sectionId);
        if (section is null)
            throw new NotFoundException(ExceptionMessages.SectionNotFound);

        if (!category.Sections.Contains(section))
            throw new NotFoundException(ExceptionMessages.SectionCategoryAlreadyExists);

        category.Sections.Remove(section);
        await _context.SaveChangesAsync();
        return category.AdaptToDto();
    }
}