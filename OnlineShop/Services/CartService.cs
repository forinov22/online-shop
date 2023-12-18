using Mapster;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models.DTOs;
using OnlineShop.Models.Mappers;

namespace OnlineShop.Services;

public interface ICartService
{
    Task<IEnumerable<CartItemDto>> GetUserCartAsync(int userId);
    Task<CartItemDto?> GetCartItemAsync(int userId, int productVersionId);
    Task<CartItemDto> CreateCartItemAsync(int userId, CartItemAdd dto);
    Task<CartItemDto?> UpdateCartItemAsync(int userId, int productVersionId, CartItemUpdate dto);
    Task<bool> DeleteCartItemAsync(int userId, int productVersionId);
    Task DeleteUserCartAsync(int userId);
}

public class CartService : ICartService
{
    private readonly OnlineShopContext _context;

    public CartService(OnlineShopContext context)
    {
        _context = context;
    }

    public async Task<CartItemDto> CreateCartItemAsync(int userId, CartItemAdd dto)
    {
        var cartItem = dto.AdaptToCartItem();
        cartItem.UserId = userId;
        await _context.CartItems.AddAsync(cartItem);
        await _context.SaveChangesAsync();
        return cartItem.AdaptToDto();
    }

    public async Task<bool> DeleteCartItemAsync(int userId, int productVersionId)
    {
        var existingCartItem = await _context.CartItems.FindAsync(new { userId = userId, productVersionId = productVersionId });

        if (existingCartItem == null) return false;

        _context.CartItems.Remove(existingCartItem);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task DeleteUserCartAsync(int userId)
    {
        var cartItems = await _context.CartItems.Where(ci => ci.UserId == userId).ToListAsync();
        _context.CartItems.RemoveRange(cartItems);
        await _context.SaveChangesAsync();
    }

    public async Task<CartItemDto?> GetCartItemAsync(int userId, int productVersionId)
    {
        return await _context.CartItems.ProjectToType<CartItemDto>()
            .FirstOrDefaultAsync(ci => ci.UserId == userId && ci.ProductVersionId == productVersionId);
    }

    public async Task<IEnumerable<CartItemDto>> GetUserCartAsync(int userId)
    {
        return await _context.CartItems.ProjectToType<CartItemDto>()
            .Where(ci => ci.UserId == userId).ToListAsync();
    }

    public async Task<CartItemDto?> UpdateCartItemAsync(int userId, int productVersionId, CartItemUpdate dto)
    {
        var existingCartItem = await _context.CartItems.FindAsync(new { userId = userId, productVersionId = productVersionId });

        if (existingCartItem == null) return null;

        existingCartItem.Quantity = dto.Quantity;
        await _context.SaveChangesAsync();
        return existingCartItem.AdaptToDto();
    }
}
