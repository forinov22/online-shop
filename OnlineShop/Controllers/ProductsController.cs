using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models.DTOs.OnlineShop.Domains;
using OnlineShop.Services;

namespace OnlineShop.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("{productId:int}")]
    public async Task<ActionResult<ProductDto>> GetProduct([FromRoute] int productId)
    {
        var product = await _productService.GetProductByIdAsync(productId);

        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] ProductAdd dto)
    {
        var product = await _productService.CreateProductAsync(dto);
        return Ok(product);
    }

    [HttpPut("{productId:int}")]
    public async Task<ActionResult<ProductDto>> UpdateProduct([FromRoute] int productId, [FromBody] ProductUpdate dto)
    {
        var updatedBrand = await _productService.UpdateProductAsync(productId, dto);

        if (updatedBrand == null)
            return NotFound();

        return Ok(updatedBrand);
    }

    [HttpDelete("{productId:int}")]
    public async Task<ActionResult<ProductDto>> DeleteProduct([FromRoute] int productId)
    {
        var deleted = await _productService.DeleteProductAsync(productId);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}