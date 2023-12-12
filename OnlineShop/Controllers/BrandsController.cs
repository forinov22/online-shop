using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models.DTOs.OnlineShop.Domains;
using OnlineShop.Services;

namespace OnlineShop.Controllers;

[Route("api/brands")]
[ApiController]
public class BrandsController : ControllerBase
{
    private readonly IBrandService _brandService;

    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BrandDto>>> GetBrands()
    {
        var brands = await _brandService.GetAllBrandsAsync();
        return Ok(brands);
    }

    [HttpGet("{brandId:int}")]
    public async Task<ActionResult<BrandDto>> GetBrand([FromRoute] int brandId)
    {
        var brand = await _brandService.GetBrandByIdAsync(brandId);
        
        if (brand == null)
            return NotFound();
        
        return Ok(brand);
    }

    [HttpPost]
    public async Task<ActionResult<BrandDto>> CreateBrand([FromBody] BrandAdd dto)
    {
        var brand = await _brandService.CreateBrandAsync(dto);
        return Ok(brand);
    }

    [HttpPut("{brandId:int}")]
    public async Task<ActionResult<BrandDto>> UpdateBrand([FromRoute] int brandId, [FromBody] BrandUpdate dto)
    {
        var updatedBrand = await _brandService.UpdateBrandAsync(brandId, dto);

        if (updatedBrand == null)
            return NotFound();

        return Ok(updatedBrand);
    }
    
    [HttpDelete("{brandId:int}")]
    public async Task<ActionResult<ColorDto>> DeleteBrand([FromRoute] int brandId)
    {
        var deleted = await _brandService.DeleteBrandAsync(brandId);
        
        if (!deleted)
            return NotFound();
        
        return NoContent();
    }
}