using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models.DTOs;
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
        return brands.ToList();
    }

    [HttpGet("{brandId:int}")]
    public async Task<ActionResult<BrandDto>> GetBrand([FromRoute] int brandId)
    {
        var brand = await _brandService.GetBrandByIdAsync(brandId);
        return brand;
    }

    [HttpPost]
    public async Task<ActionResult<BrandDto>> CreateBrand([FromBody] BrandAdd dto)
    {
        var brand = await _brandService.CreateBrandAsync(dto);
        return brand;
    }

    [HttpPut("{brandId:int}")]
    public async Task<ActionResult<BrandDto>> UpdateBrand([FromRoute] int brandId, [FromBody] BrandUpdate dto)
    {
        var updatedBrand = await _brandService.UpdateBrandAsync(brandId, dto);
        return updatedBrand;
    }
    
    [HttpDelete("{brandId:int}")]
    public async Task<ActionResult<BrandDto>> DeleteBrand([FromRoute] int brandId)
    {
        var deleted = await _brandService.DeleteBrandAsync(brandId);
        return deleted;
    }
}