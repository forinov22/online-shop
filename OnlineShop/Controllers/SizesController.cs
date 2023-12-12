using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models.DTOs.OnlineShop.Domains;
using OnlineShop.Services;

namespace OnlineShop.Controllers;

[Route("api/sizes")]
[ApiController]
public class SizesController : ControllerBase
{
    private readonly ISizeService _sizeService;

    public SizesController(ISizeService sizeService)
    {
        _sizeService = sizeService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SizeDto>>> GetSizes()
    {
        var sizes = await _sizeService.GetAllSizesAsync();
        return Ok(sizes);
    }

    [HttpGet("{sizeId:int}")]
    public async Task<ActionResult<SizeDto>> GetSize([FromRoute] int sizeId)
    {
        var size = await _sizeService.GetSizeByIdAsync(sizeId);
        
        if (size == null)
            return NotFound();
        
        return Ok(size);
    }

    [HttpPost]
    public async Task<ActionResult<SizeDto>> CreateSize([FromBody] SizeAdd dto)
    {
        var size = await _sizeService.CreateSizeAsync(dto);
        return Ok(size);
    }
    
    [HttpDelete("{sizeId:int}")]
    public async Task<ActionResult<SizeDto>> DeleteSisze([FromRoute] int sizeId)
    {
        var deleted = await _sizeService.DeleteSizeAsync(sizeId);
        
        if (!deleted)
            return NotFound();
        
        return NoContent();
    }
}