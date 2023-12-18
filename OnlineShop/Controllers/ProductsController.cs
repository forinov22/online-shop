using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models.DTOs;
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
        return product;
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] ProductAdd dto)
    {
        var product = await _productService.CreateProductAsync(dto);
        return product;
    }

    [HttpPut("{productId:int}")]
    public async Task<ActionResult<ProductDto>> UpdateProduct([FromRoute] int productId, [FromBody] ProductUpdate dto)
    {
        var brand = await _productService.UpdateProductAsync(productId, dto);
        return brand;
    }

    [HttpDelete("{productId:int}")]
    public async Task<ActionResult<ProductDto>> DeleteProduct([FromRoute] int productId)
    {
        var deleted = await _productService.DeleteProductAsync(productId);
        return deleted;
    }
}