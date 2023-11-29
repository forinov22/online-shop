using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using OnlineShop.Models.Dto;
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
        var brandModels = _mapper.Map<IEnumerable<BrandDto>>(brands);
        return Ok(brandModels);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Brand>> GetBrand([FromRoute] int id)
    {
        var brand = await _brandService.GetBrandByIdAsync(id);
        
        if (brand == null) {
            return NotFound();
        }

        var brandModel = _mapper.Map<BrandDto>(brand);
        return Ok(brandModel);
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
        var newBrand = await _brandService.CreateBrandAsync(brand);
        var brandModel = _mapper.Map<BrandDto>(newBrand);
        return CreatedAtAction(nameof(GetBrand), new { id = brandModel.Id }, brandModel);
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
