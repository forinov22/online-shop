using DbFirstApp.Data;
using OnlineShop.Models;

namespace OnlineShop.Services;

public interface IProductVersionService {
    public Task<Color> CreateColorAsync(Color color);
    public Task<bool> DeleteColorAsync(int id);
    public Task<Size> CreateSizeAsync(Size size);
    public Task<bool> DeleteSizeAsync(int id);
};

public class ProductVersionService : IProductVersionService
{
    private readonly OnlineShopContext context;

    public ProductVersionService(OnlineShopContext context)
    {
        this.context = context;
    }

    public async Task<Color> CreateColorAsync(Color color) {
        await context.Colors.AddAsync(color);
        await context.SaveChangesAsync();
        return color;
    }

    public async Task<bool> DeleteColorAsync(int id) {
        var color = await context.Colors.FindAsync(id);

        if (color == null)
            return false;

        context.Colors.Remove(color);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<Size> CreateSizeAsync(Size size) {
        await context.Sizes.AddAsync(size);
        await context.SaveChangesAsync();
        return size;
    }

    public async Task<bool> DeleteSizeAsync(int id) {
        var size = await context.Sizes.FindAsync(id);

        if (size == null)
            return false;

        context.Sizes.Remove(size);
        await context.SaveChangesAsync();
        return true;
    }
}
