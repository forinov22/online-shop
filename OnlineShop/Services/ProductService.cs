using DbFirstApp.Data;
using OnlineShop.Models;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Services;

public interface IProductService {
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product?> GetProductByIdAsync(int id);
    Task<Product> CreateProductAsync(Product product);
    Task<Product?> UpdateProductAsync(int id, Product updatedProduct);
    Task<bool> DeleteProductAsync(int id);
};

public class ProductService : IProductService
{
    private readonly OnlineShopContext _ctx;

    public ProductService(OnlineShopContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        await _ctx.Products.AddAsync(product);
        await _ctx.SaveChangesAsync();
        return product;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var existingProduct = await _ctx.Products.FindAsync(id);

        if (existingProduct == null) 
            return false;

        _ctx.Products.Remove(existingProduct);
        await _ctx.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _ctx.Products.ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _ctx.Products.FindAsync(id);
    }

    public async Task<Product?> UpdateProductAsync(int id, Product updatedProduct)
    {
        var product = await _ctx.Products.FindAsync(id);

        if (product != null) {
            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.BrandId = updatedProduct.BrandId;
            product.CategoryId = updatedProduct.CategoryId;
            product.AverageRating = updatedProduct.AverageRating;
            await _ctx.SaveChangesAsync();
        }

        return product;
    }

    public async Task<ProductVersion> CreateProductVersionAsync(ProductVersion productVersion) {
        await _ctx.ProductVersions.AddAsync(productVersion);
        await _ctx.SaveChangesAsync();
        return productVersion;
    }

    public async Task<ProductVersion?> UpdateProductVersionAsync(int productVersionId, ProductVersion updatedProductVersion) {
        var productVersion = await _ctx.ProductVersions.FindAsync(productVersionId);

        if (productVersion != null) {
            productVersion.Quantity = updatedProductVersion.Quantity;
            productVersion.Sku = updatedProductVersion.Sku;
            productVersion.ProductId = updatedProductVersion.ProductId;
            productVersion.SizeId = updatedProductVersion.SizeId;
            productVersion.ColorId = updatedProductVersion.ColorId;
            await _ctx.SaveChangesAsync();
        }

        return productVersion;
    }

}
