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
    Task<ProductVersionDto> UpdateProductVersionAsync(int productVersionId, ProductVersionUpdate dto);
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
        var productVersion = dto.AdaptToProductVersion();
        await _context.ProductVersions.AddAsync(productVersion);
        await _context.SaveChangesAsync();
        var existingProductVersion = await _context.ProductVersions.ProjectToType<ProductVersionDto>()
            .FirstAsync(pv => pv.Id == productVersion.Id);
        return existingProductVersion;
    }

    public async Task<ProductVersionDto> UpdateProductVersionAsync(int productVersionId, ProductVersionUpdate dto)
    {
        var existingProductVersion = await _context.ProductVersions.FindAsync(productVersionId);

        if (existingProductVersion == null)
            throw new NotFoundException(ExceptionMessages.ProductVersionNotFound);

        existingProductVersion.Quantity = dto.Quantity;
        existingProductVersion.Sku = dto.Sku;
        existingProductVersion.ProductId = dto.ProductId;
        existingProductVersion.SizeId = dto.SizeId;
        existingProductVersion.ColorId = dto.ColorId;

        await _context.SaveChangesAsync();
        return existingProductVersion.AdaptToDto();
    }

    public async Task<ProductVersionDto> DeleteProductVersionAsync(int productVersionId)
    {
        var existingProductVersion = await _context.ProductVersions.FindAsync(productVersionId);

        if (existingProductVersion == null)
            throw new NotFoundException(ExceptionMessages.ProductVersionNotFound);

        _context.ProductVersions.Remove(existingProductVersion);
        await _context.SaveChangesAsync();
        return existingProductVersion.AdaptToDto();
    }
}