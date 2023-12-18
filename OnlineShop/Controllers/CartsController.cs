using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models.DTOs;
using OnlineShop.Services;
using System.Security.Claims;

namespace OnlineShop.Controllers;

[Authorize(Roles = "User")]
[Route("api/carts")]
[ApiController]
public class CartsController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartsController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CartItemDto>>> GetUserCart()
    {
        if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            return Forbid();

        var cartItmes = await _cartService.GetUserCartAsync(userId);
        return cartItmes.ToList();
    }

    [HttpGet("{productVersionId:int}")]
    public async Task<ActionResult<CartItemDto>> GetCartItem([FromRoute] int productVersionId)
    {
        if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            return Forbid();

        var cartItem = await _cartService.GetCartItemAsync(userId, productVersionId);
        return cartItem == null ? NotFound() : cartItem;
    }

    [HttpPost]
    public async Task<ActionResult<CartItemDto>> CreateCartItem([FromBody] CartItemAdd dto)
    {
        if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            return Forbid();

        var cartItem = await _cartService.CreateCartItemAsync(userId, dto);
        return CreatedAtAction(nameof(GetCartItem), new { userId = cartItem.UserId, productVersionId = cartItem.ProductVersionId });
    }

    [HttpPut("{productVersionId:int}")]
    public async Task<ActionResult<CartItemDto>> UpdateCartItme([FromRoute] int productVersionId, [FromBody] CartItemUpdate dto)
    {
        if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            return Forbid();

        var cartItem = await _cartService.UpdateCartItemAsync(userId, productVersionId, dto);
        return cartItem == null ? NotFound() : cartItem;
    }

    [HttpDelete("{productVersionId:int}")]
    public async Task<ActionResult> DeleteCartItem([FromRoute] int productVersionId)
    {
        if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            return Forbid();

        var deleted = await _cartService.DeleteCartItemAsync(userId, productVersionId);
        return deleted ? NoContent() : NotFound();
    }
}
