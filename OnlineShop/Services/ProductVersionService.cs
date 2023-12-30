using Mapster;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Exceptions;
using OnlineShop.Models.DTOs;
using OnlineShop.Models.Mappers;

namespace OnlineShop.Services;

public interface IProductVersionService
{
    Task<ProductVersionDto> GetProductVersionByIdAsync(int productVersionId);
    Task<IEnumerable<ProductVersionDto>> GetAllProductVersionsByProductIdAsync(int productId);
    Task<ProductVersionDto> CreateProductVersionAsync(ProductVersionAdd dto);
    Task<ProductVersionDto> UpdateProductVersionQuantityAsync(int productVersionId, ProductVersionUpdate dto);
    Task<ProductVersionDto> DeleteProductVersionAsync(int productVersionId);
}

public class ProductVersionService : IProductVersionService
{
    private readonly OnlineShopContext _context;

    public ProductVersionService(OnlineShopContext context)
    {
        _context = context;
    }

    public async Task<ProductVersionDto> GetProductVersionByIdAsync(int productVersionId)
    {
        var productVersion = await _context.ProductVersions.ProjectToType<ProductVersionDto>()
            .FirstOrDefaultAsync(pv => pv.Id == productVersionId);
        if (productVersion == null)
            throw new NotFoundException(ExceptionMessages.ProductVersionNotFound);

        return productVersion;
    }

    public async Task<IEnumerable<ProductVersionDto>> GetAllProductVersionsByProductIdAsync(int productId)
    {
        return await _context.ProductVersions.ProjectToType<ProductVersionDto>()
            .Where(pv => pv.ProductId == productId).ToListAsync();
    }

    public async Task<ProductVersionDto> CreateProductVersionAsync(ProductVersionAdd dto)
    {
        var product = await _context.Products.FindAsync(dto.ProductId);
        if (product is null)
            throw new NotFoundException(ExceptionMessages.ProductNotFound);

        var size = await _context.Sizes.FindAsync(dto.SizeId);
        if (size is null)
            throw new NotFoundException(ExceptionMessages.SizeNotFound);

        var color = await _context.Colors.FindAsync(dto.ColorId);
        if (color is null)
            throw new NotFoundException(ExceptionMessages.ColorNotFound);
        
        var productVersion = dto.AdaptToProductVersion();
        await _context.ProductVersions.AddAsync(productVersion);
        await _context.SaveChangesAsync();
        return productVersion.AdaptToDto();
    }

    public async Task<ProductVersionDto> UpdateProductVersionQuantityAsync(int productVersionId, ProductVersionUpdate dto)
    {
        var existingProductVersion = await _context.ProductVersions.FindAsync(productVersionId);

        if (existingProductVersion == null)
            throw new NotFoundException(ExceptionMessages.ProductVersionNotFound);

        existingProductVersion.Quantity = dto.Quantity;

        await _context.SaveChangesAsync();
        return existingProductVersion.AdaptToDto();
    }

    public async Task<ProductVersionDto> DeleteProductVersionAsync(int productVersionId)
    {
        var existingProductVersion = await _context.ProductVersions.Include(pv => new { pv.CartItems, pv.OrderItems })
            .FirstOrDefaultAsync(pv => pv.Id == productVersionId);
        if (existingProductVersion == null)
            throw new NotFoundException(ExceptionMessages.ProductVersionNotFound);

        if (existingProductVersion.OrderItems.Count > 0)
            throw new InvalidOperationException(ExceptionMessages.ProductVersionHasOrders);

        foreach (var ci in existingProductVersion.CartItems)
        {
            _context.Remove(ci);
        }
        
        _context.ProductVersions.Remove(existingProductVersion);
        await _context.SaveChangesAsync();
        return existingProductVersion.AdaptToDto();
    }
}