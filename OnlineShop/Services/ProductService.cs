using Mapster;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs.OnlineShop.Domains;

namespace OnlineShop.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    Task<ProductDto?> GetProductByIdAsync(int productId);
    Task<ProductDto> CreateProductAsync(ProductAdd dto);
    Task<ProductDto?> UpdateProductAsync(int productId, ProductUpdate dto);
    Task<bool> DeleteProductAsync(int productId);
}

public class ProductService : IProductService
{
    private readonly OnlineShopContext _context;

    public ProductService(OnlineShopContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        return await _context.Products.ProjectToType<ProductDto>().ToListAsync();
    }

    public async Task<ProductDto?> GetProductByIdAsync(int productId)
    {
        return await _context.Products.ProjectToType<ProductDto>()
            .FirstOrDefaultAsync(p => p.Id == productId);
    }

    public async Task<ProductDto> CreateProductAsync(ProductAdd dto)
    {
        var product = dto.AdaptToProduct();
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        var existingProduct = await _context.Products.ProjectToType<ProductDto>()
            .FirstAsync(p => p.Id == product.Id);
        return existingProduct;
    }

    public async Task<ProductDto?> UpdateProductAsync(int productId, ProductUpdate dto)
    {
        var existingProduct = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == productId);

        if (existingProduct == null)
            return null;

        existingProduct.Name = dto.Name;
        existingProduct.Price = dto.Price;
        existingProduct.BrandId = dto.BrandId;
        existingProduct.CategoryId = dto.CategoryId;
        existingProduct.AverageRating = dto.AverageRating;

        await _context.SaveChangesAsync();
        return existingProduct.AdaptToDto();
    }

    public async Task<bool> DeleteProductAsync(int productId)
    {
        var existingProduct = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == productId);

        if (existingProduct == null)
            return false;

        _context.Products.Remove(existingProduct);
        await _context.SaveChangesAsync();
        return true;
    }
}