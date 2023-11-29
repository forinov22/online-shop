using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using OnlineShop.Models.Dto;
using OnlineShop.Services;

namespace OnlineShop.Controllers;

[Route("api/productversions")]
[ApiController]
public class ProductVersionsController : ControllerBase
{
    private readonly IProductVersionService productVersionService;
    private readonly IMapper mapper;

    public ProductVersionsController(IProductVersionService productVersionService,
                                     IMapper mapper)
    {
        this.productVersionService = productVersionService;
        this.mapper = mapper;
    }

    [HttpPost("sizes")]
    public async Task<IActionResult> AddSize([FromBody] CreateSizeDto dto) {
        var size = mapper.Map<Size>(dto);
        var newSize = await productVersionService.CreateSizeAsync(size);
        var sizeDto = mapper.Map<SizeDto>(newSize);
        return Ok(sizeDto);
    }

    [HttpDelete("sizes")]
    public async Task<IActionResult> RemoveSize([FromRoute] int id) {
        var deleted = await productVersionService.DeleteSizeAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }

    [HttpPost("colors")]
    public async Task<IActionResult> AddColor([FromBody] CreateColorDto dto) {
        var color = mapper.Map<Color>(dto);
        var newColor = await productVersionService.CreateColorAsync(color);
        var colorDto = mapper.Map<ColorDto>(newColor);
        return Ok(colorDto);
    }

    [HttpDelete("colors")]
    public async Task<IActionResult> RemoveColor([FromRoute] int id) {
        var deleted = await productVersionService.DeleteColorAsync(id);

        if (!deleted)
            return NotFound();
            
        return NoContent();
    }
}
