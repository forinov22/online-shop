using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models.DTOs.OnlineShop.Domains;
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
        return Ok(categories);
    }

    [HttpGet("{categoryId:int}")]
    public async Task<ActionResult<CategoryDto>> GetCategory([FromRoute] int categoryId)
    {
        var category = await _categoryService.GetCategoryByIdAsync(categoryId);
        
        if (category == null)
            return NotFound();
        
        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDto>> CreateCategory([FromBody] CategoryAdd dto)
    {
        var category = await _categoryService.CreateCategoryAsync(dto);
        return Ok(category);
    }

    [HttpPut("{categoryId:int}")]
    public async Task<ActionResult<CategoryDto>> UpdateCategory([FromRoute] int categoryId, [FromBody] CategoryUpdate dto)
    {
        var updatedCategory = await _categoryService.UpdateCategoryAsync(categoryId, dto);

        if (updatedCategory == null)
            return NotFound();

        return Ok(updatedCategory);
    }
    
    [HttpDelete("{categoryId:int}")]
    public async Task<ActionResult<ColorDto>> DeleteCategory([FromRoute] int categoryId)
    {
        var deleted = await _categoryService.DeleteCategoryAsync(categoryId);
        
        if (!deleted)
            return NotFound();
        
        return NoContent();
    }
}