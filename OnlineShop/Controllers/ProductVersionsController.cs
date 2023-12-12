using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models.DTOs.OnlineShop.Domains;
using OnlineShop.Services;

namespace OnlineShop.Controllers;

[Route("api/productVersions")]
[ApiController]
public class ProductVersionsController : ControllerBase
{
    private readonly IProductVersionService _productVersionService;

    public ProductVersionsController(IProductVersionService productVersionService)
    {
        _productVersionService = productVersionService;
    }

    [HttpGet("{productVersionId:int}")]
    public async Task<ActionResult<ProductVersionDto>> GetProductVersion([FromRoute] int productVersionId)
    {
        var productVersion = await _productVersionService.GetProductVersionByIdAsync(productVersionId);

        if (productVersion == null)
            return NoContent();

        return Ok(productVersion);
    }
    
    [HttpGet("product/{productId:int}")]
    public async Task<ActionResult<ProductVersionDto>> GetProductVersions([FromRoute] int productId)
    {
        var productVersions = await _productVersionService.GetAllProductVersionsByProductIdAsync(productId);
        
        return Ok(productVersions);
    }

    [HttpPost]
    public async Task<ActionResult<ProductVersionDto>> CreateProductVersion([FromBody] ProductVersionAdd dto)
    {
        var productVersion = await _productVersionService.CreateProductVersionAsync(dto);
        return Ok(productVersion);
    }

    [HttpPut("{productVersionId:int}")]
    public async Task<ActionResult<ProductVersionDto>> UpdateProductVersion([FromRoute] int productId,
        [FromBody] ProductVersionUpdate dto)
    {
        var updatedProductVersion = await _productVersionService.UpdateProductVersionAsync(productId, dto);

        if (updatedProductVersion == null)
            return NotFound();

        return Ok(updatedProductVersion);
    }
    
    [HttpDelete("{productVersionId:int}")]
    public async Task<ActionResult<ProductVersionDto>> DeleteProductVersion([FromRoute] int productId)
    {
        var deleted = await _productVersionService.DeleteProductVersionAsync(productId);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}