using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models.DTOs;
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
        return productVersion;
    }
    
    [HttpGet("product/{productId:int}")]
    public async Task<ActionResult<IEnumerable<ProductVersionDto>>> GetProductVersions([FromRoute] int productId)
    {
        var productVersions = await _productVersionService.GetAllProductVersionsByProductIdAsync(productId);
        return productVersions.ToList();
    }

    [HttpPost]
    public async Task<ActionResult<ProductVersionDto>> CreateProductVersion([FromBody] ProductVersionAdd dto)
    {
        var productVersion = await _productVersionService.CreateProductVersionAsync(dto);
        return productVersion;
    }

    [HttpPut("{productVersionId:int}")]
    public async Task<ActionResult<ProductVersionDto>> UpdateProductVersion([FromRoute] int productId,
        [FromBody] ProductVersionUpdate dto)
    {
        var productVersion = await _productVersionService.UpdateProductVersionAsync(productId, dto);
        return productVersion;
    }
    
    [HttpDelete("{productVersionId:int}")]
    public async Task<ActionResult<ProductVersionDto>> DeleteProductVersion([FromRoute] int productId)
    {
        var deleted = await _productVersionService.DeleteProductVersionAsync(productId);
        return deleted;
    }
}