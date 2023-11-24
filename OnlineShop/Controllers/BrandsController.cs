using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
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
    public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
    {
        var brands = await _brandService.GetAllBrandsAsync();
        return Ok(brands);
    }

    [HttpGet]
    public async Task<ActionResult<Brand>> GetBrand([FromRoute] int id)
    {
        var brand = await _brandService.GetBrandByIdAsync(id);
        
        if (brand == null) {
            return NotFound();
        }

        return brand;
    }

    [HttpPut]
    public async Task<IActionResult> PutBrand([FromRoute] int id, Brand brand)
    {
        if (id != brand.Id)
        {
            return BadRequest();
        }

        var updatedBrand = await _brandService.UpdateBrandAsync(id, brand);

        if (updatedBrand == null) {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Brand>> PostBrand(Brand brand)
    {
        await _brandService.CreateBrandAsync(brand);

        return CreatedAtAction("GetBrand", new { id = brand.Id }, brand);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBrand([FromRoute] int id)
    {
        if (!await _brandService.DeleteBrandAsync(id)) {
            return NotFound();
        }

        return NoContent();
    }
}
