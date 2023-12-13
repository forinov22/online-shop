using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models.DTOs;
using OnlineShop.Services;

namespace OnlineShop.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return categories.ToList();
    }

    [HttpGet("{categoryId:int}")]
    public async Task<ActionResult<CategoryDto>> GetCategory([FromRoute] int categoryId)
    {
        var category = await _categoryService.GetCategoryByIdAsync(categoryId);
        return category;
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDto>> CreateCategory([FromBody] CategoryAdd dto)
    {
        var category = await _categoryService.CreateCategoryAsync(dto);
        return category;
    }

    [HttpPut("{categoryId:int}")]
    public async Task<ActionResult<CategoryDto>> UpdateCategory([FromRoute] int categoryId, [FromBody] CategoryUpdate dto)
    {
        var category = await _categoryService.UpdateCategoryAsync(categoryId, dto);
        return category;
    }
    
    [HttpDelete("{categoryId:int}")]
    public async Task<ActionResult<CategoryDto>> DeleteCategory([FromRoute] int categoryId)
    {
        var deleted = await _categoryService.DeleteCategoryAsync(categoryId);
        return deleted;
    }
}