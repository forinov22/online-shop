using Mapster;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Exceptions;
using OnlineShop.Models.DTOs;
using OnlineShop.Models.Mappers;

namespace OnlineShop.Services;

public interface ICartService
{
    Task<IEnumerable<CartItemDto>> GetUserCartAsync(int userId);
    Task<CartItemDto> GetCartItemAsync(int userId, int productVersionId);
    Task<CartItemDto> CreateCartItemAsync(int userId, CartItemAdd dto);
    Task<CartItemDto> UpdateCartItemQuantityAsync(int userId, int productVersionId, CartItemUpdate dto);
    Task<CartItemDto> DeleteCartItemAsync(int userId, int productVersionId);
    Task<UserDto> DeleteUserCartAsync(int userId);
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
        var user = await _context.Users.FindAsync(userId);
        if (user is null)
            throw new NotFoundException(ExceptionMessages.UserNotFound);

        var pv = await _context.ProductVersions.FindAsync(dto.ProductVersionId);
        if (pv is null)
            throw new NotFoundException(ExceptionMessages.ProductVersionNotFound);

        if (dto.Quantity <= 0 || dto.Quantity > pv.Quantity)
            throw new InvalidOperationException(ExceptionMessages.WrongQuantity);

        var cartItem = dto.AdaptToCartItem();
        cartItem.UserId = userId;
        await _context.CartItems.AddAsync(cartItem);
        await _context.SaveChangesAsync();
        return cartItem.AdaptToDto();
    }

    public async Task<CartItemDto> DeleteCartItemAsync(int userId, int productVersionId)
    {
        var existingCartItem = await _context.CartItems.FindAsync(new { userId = userId, productVersionId = productVersionId });

        if (existingCartItem is null)
            throw new NotFoundException(ExceptionMessages.CartItemNotFound);

        _context.CartItems.Remove(existingCartItem);
        await _context.SaveChangesAsync();
        return existingCartItem.AdaptToDto();
    }

    public async Task<UserDto> DeleteUserCartAsync(int userId)
    {
        var user = await _context.Users.ProjectToType<UserDto>()
            .FirstOrDefaultAsync(u => u.Id == userId);
        if (user is null)
            throw new NotFoundException(ExceptionMessages.UserNotFound);

        var cartItems = await _context.CartItems.Where(ci => ci.UserId == userId).ToListAsync();
        _context.CartItems.RemoveRange(cartItems);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<CartItemDto> GetCartItemAsync(int userId, int productVersionId)
    {
        var ci = await _context.CartItems.ProjectToType<CartItemDto>()
            .FirstOrDefaultAsync(ci => ci.UserId == userId && ci.ProductVersionId == productVersionId);
        if (ci is null)
            throw new NotFoundException(ExceptionMessages.CartItemNotFound);
        
        return ci;
    }

    public async Task<IEnumerable<CartItemDto>> GetUserCartAsync(int userId)
    {
        var user = await _context.Users.ProjectToType<UserDto>()
            .FirstOrDefaultAsync(u => u.Id == userId);
        if (user is null)
            throw new NotFoundException(ExceptionMessages.UserNotFound);

        return await _context.CartItems.ProjectToType<CartItemDto>()
            .Where(ci => ci.UserId == userId).ToListAsync();
    }

    public async Task<CartItemDto> UpdateCartItemQuantityAsync(int userId, int productVersionId, CartItemUpdate dto)
    {
        var existingCartItem = await _context.CartItems.FindAsync(new { userId = userId, productVersionId = productVersionId });
        if (existingCartItem == null) 
            throw new NotFoundException(ExceptionMessages.CartItemNotFound);

        var pv = await _context.ProductVersions.FindAsync(productVersionId);
        if (dto.Quantity <= 0 || dto.Quantity > pv.Quantity)
            throw new InvalidOperationException(ExceptionMessages.WrongQuantity);

        existingCartItem.Quantity = dto.Quantity;
        await _context.SaveChangesAsync();
        return existingCartItem.AdaptToDto();
    }
}
