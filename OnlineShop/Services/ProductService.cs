using Mapster;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Exceptions;
using OnlineShop.Models.DTOs;
using OnlineShop.Models.Mappers;

namespace OnlineShop.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    Task<ProductDto> GetProductByIdAsync(int productId);
    Task<ProductDto> CreateProductAsync(ProductAdd dto);
    Task<ProductDto> UpdateProductAsync(int productId, ProductUpdate dto);
    Task<ProductDto> DeleteProductAsync(int productId);
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

    public async Task<ProductDto> GetProductByIdAsync(int productId)
    {
        var product = await _context.Products.ProjectToType<ProductDto>()
            .FirstOrDefaultAsync(p => p.Id == productId);

        if (product == null)
            throw new NotFoundException(ExceptionMessages.ProductNotFound);

        return product;
    }

    public async Task<ProductDto> CreateProductAsync(ProductAdd dto)
    {
        var brand = await _context.Brands.FindAsync(dto.BrandId);
        if (brand is null)
            throw new NotFoundException(ExceptionMessages.BrandNotFound);
        
        var category = await _context.Categories.FindAsync(dto.CategoryId);
        if (category is null)
            throw new NotFoundException(ExceptionMessages.CategoryNotFound);
        
        var product = dto.AdaptToProduct();
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product.AdaptToDto();
    }

    public async Task<ProductDto> UpdateProductAsync(int productId, ProductUpdate dto)
    {
        var existingProduct = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == productId);

        if (existingProduct == null)
            throw new NotFoundException(ExceptionMessages.ProductNotFound);
        
        existingProduct.Price = dto.Price;
        existingProduct.AverageRating = dto.AverageRating;

        await _context.SaveChangesAsync();
        return existingProduct.AdaptToDto();
    }

    public async Task<ProductDto> DeleteProductAsync(int productId)
    {
        var existingProduct = await _context.Products.Include(p => new {p.Media, p.ProductVersions, p.Reviews})
            .FirstOrDefaultAsync(p => p.Id == productId);
        if (existingProduct == null)
            throw new NotFoundException(ExceptionMessages.ProductNotFound);

        if (existingProduct.ProductVersions.Count > 0)
            throw new InvalidOperationException(ExceptionMessages.ProductHasProductVersions);
        
        foreach (var m in existingProduct.Media)
        {
            _context.Remove(m);
        }

        foreach (var r in existingProduct.Reviews)
        {
            _context.Remove(r);
        }
        
        _context.Products.Remove(existingProduct);
        await _context.SaveChangesAsync();
        return existingProduct.AdaptToDto();
    }
}