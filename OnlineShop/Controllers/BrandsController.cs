using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using OnlineShop.Services;

namespace OnlineShop.Controllers;

[Route("api/brands")]
[ApiController]
public class BrandsController : ControllerBase
{
    private readonly IBrandService _brandService;
    private readonly IMapper _mapper;

    public BrandsController(IBrandService brandService, IMapper mapper)
    {
        _brandService = brandService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
    {
        var brands = await _brandService.GetAllBrandsAsync();
        var brandModels = _mapper.Map<BrandDto>(brands);
        return Ok(brandModels);
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
    public async Task<IActionResult> PutBrand([FromRoute] int id, UpdateBrandDto dto)
    {
        var brand = _mapper.Map<Brand>(dto);
        var updatedBrand = await _brandService.UpdateBrandAsync(id, brand);

        if (updatedBrand == null) {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Brand>> PostBrand(CreateBrandDto dto)
    {
        var brand = _mapper.Map<Brand>(dto);
        await _brandService.CreateBrandAsync(brand);

        return CreatedAtAction("GetBrand", new { id = brand.Id }, brand);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBrand([FromRoute] int id)
    {
        var deleted = await _brandService.DeleteBrandAsync(id);
        
        if (!deleted) {
            return NotFound();
        }

        return NoContent();
    }
}
