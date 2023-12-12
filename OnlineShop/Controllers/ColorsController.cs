using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models.DTOs.OnlineShop.Domains;
using OnlineShop.Services;

namespace OnlineShop.Controllers;

[Route("api/colors")]
[ApiController]
public class ColorsController : ControllerBase
{
    private readonly IColorService _colorService;

    public ColorsController(IColorService colorService)
    {
        _colorService = colorService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ColorDto>>> GetColors()
    {
        var colors = await _colorService.GetAllColorsAsync();
        return Ok(colors);
    }

    [HttpGet("{colorId:int}")]
    public async Task<ActionResult<ColorDto>> GetColor([FromRoute] int colorId)
    {
        var color = await _colorService.GetColorByIdAsync(colorId);
        
        if (color == null)
            return NotFound();
        
        return Ok(color);
    }

    [HttpPost]
    public async Task<ActionResult<ColorDto>> CreateColor([FromBody] ColorAdd dto)
    {
        var color = await _colorService.CreateColorAsync(dto);
        return Ok(color);
    }
    
    [HttpDelete("{colorId:int}")]
    public async Task<ActionResult<ColorDto>> DeleteSisze([FromRoute] int colorId)
    {
        var deleted = await _colorService.DeleteColorAsync(colorId);
        
        if (!deleted)
            return NotFound();
        
        return NoContent();
    }
}