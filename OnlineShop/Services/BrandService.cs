using Mapster;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Exceptions;
using OnlineShop.Models.DTOs;
using OnlineShop.Models.Mappers;

namespace OnlineShop.Services;

public interface IBrandService
{
    Task<IEnumerable<BrandDto>> GetAllBrandsAsync();
    Task<BrandDto> GetBrandByIdAsync(int brandId);
    Task<BrandDto> CreateBrandAsync(BrandAdd dto);
    Task<BrandDto> UpdateBrandNameAsync(int brandId, BrandUpdate dto);
    Task<BrandDto> DeleteBrandAsync(int brandId);
}

public class BrandService : IBrandService
{
    private readonly OnlineShopContext _context;

    public BrandService(OnlineShopContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
    {
        return await _context.Brands.ProjectToType<BrandDto>().ToListAsync();
    }

    public async Task<BrandDto> GetBrandByIdAsync(int brandId)
    {
        var brand = await _context.Brands.ProjectToType<BrandDto>()
            .FirstOrDefaultAsync(b => b.Id == brandId);

        if (brand == null)
            throw new NotFoundException(ExceptionMessages.BrandNotFound);

        return brand;
    }

    public async Task<BrandDto> CreateBrandAsync(BrandAdd dto)
    {
        var candidate = await _context.Brands.FirstOrDefaultAsync(b => b.Name == dto.Name);
        if (candidate is not null)
            throw new AlreadyExistsException(ExceptionMessages.BrandAlreadyExists);

        var brand = dto.AdaptToBrand();
        await _context.Brands.AddAsync(brand);
        await _context.SaveChangesAsync();
        return brand.AdaptToDto();
    }

    public async Task<BrandDto> UpdateBrandNameAsync(int brandId, BrandUpdate dto)
    {
        var existingBrand = await _context.Brands.FindAsync(brandId);

        if (existingBrand is null)
            throw new NotFoundException(ExceptionMessages.BrandNotFound);

        var candidate = await _context.Brands.FirstOrDefaultAsync(b => b.Name == dto.Name);
        if (candidate is not null)
            throw new AlreadyExistsException(ExceptionMessages.BrandAlreadyExists);

        existingBrand.Name = dto.Name;
        
        await _context.SaveChangesAsync();
        return existingBrand.AdaptToDto();
    }

    public async Task<BrandDto> DeleteBrandAsync(int brandId)
    {
        var existingBrand = await _context.Brands.Include(b => b.Products)
            .FirstOrDefaultAsync(b => b.Id == brandId);

        if (existingBrand == null)
            throw new NotFoundException(ExceptionMessages.BrandNotFound);

        if (existingBrand.Products.Count > 0)
            throw new InvalidOperationException(ExceptionMessages.BrandHasProducts);

        _context.Brands.Remove(existingBrand);
        await _context.SaveChangesAsync();
        return existingBrand.AdaptToDto();
    }
}