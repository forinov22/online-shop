using DbFirstApp.Data;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;

namespace OnlineShop.Services;

public interface ICartService {
    Task<IEnumerable<CartItem>> GetAllCartItemsByUserIdAsync(int userId);
    Task<CartItem> AddProductToCartAsync(int userId, int productVersionId, int quantity);
    Task<bool> RemoveProductFromCartAsync(int userId, int productVersionId, int quantity);
};

public class CartService : ICartService
{
    private readonly OnlineShopContext context;

    public CartService(OnlineShopContext context)
    {
        this.context = context;
    }

    public async Task<CartItem> AddProductToCartAsync(int userId, int productVersionId, int quantity)
    {
        var cartItem = await context.CartItems.
            FindAsync(new {UserId = userId, ProductVersionId = productVersionId});

        if (cartItem == null) {
            cartItem = new CartItem { UserId = userId, ProductVersionId = productVersionId, Quantity = quantity };
            await context.CartItems.AddAsync(cartItem);
        }

        cartItem.Quantity += quantity;
        
        await context.SaveChangesAsync();
        return cartItem;
    }

    public async Task<IEnumerable<CartItem>> GetAllCartItemsByUserIdAsync(int userId)
    {
        var cartItems = await context.CartItems.Where(ci => ci.UserId == userId).ToListAsync();
        return cartItems;
    }

    public async Task<bool> RemoveProductFromCartAsync(int userId, int productVersionId, int quantity)
    {
        var cartItem = await context.CartItems.
            FindAsync(new {UserId = userId, ProductVersionId = productVersionId});

        if (cartItem == null || cartItem.Quantity - quantity < 0)
            return false;

        cartItem.Quantity -= quantity;
        
        await context.SaveChangesAsync();
        return true;
    }
}
