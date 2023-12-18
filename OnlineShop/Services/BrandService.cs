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
    Task<BrandDto> UpdateBrandAsync(int brandId, BrandUpdate dto);
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
        //var brand = await _context.Brands.ProjectToType<BrandDto>()
        //    .FirstOrDefaultAsync(b => b.Id == brandId);

        var brand = await _context.Brands.Include(b => b.Products).FirstOrDefaultAsync(b => b.Id == brandId);


        if (brand == null)
            throw new NotFoundException(ExceptionMessages.BrandNotFound);

        return brand.AdaptToDto();
    }

    public async Task<BrandDto> CreateBrandAsync(BrandAdd dto)
    {
        var brand = dto.AdaptToBrand();
        await _context.Brands.AddAsync(brand);
        await _context.SaveChangesAsync();
        var existingBrand = await _context.Brands.ProjectToType<BrandDto>()
            .FirstAsync(b => b.Id == brand.Id);
        return existingBrand;
    }

    public async Task<BrandDto> UpdateBrandAsync(int brandId, BrandUpdate dto)
    {
        var existingBrand = await _context.Brands.FindAsync(brandId);

        if (existingBrand == null)
            throw new NotFoundException(ExceptionMessages.BrandNotFound);

        existingBrand.Name = dto.Name;
        
        await _context.SaveChangesAsync();
        return existingBrand.AdaptToDto();
    }

    public async Task<BrandDto> DeleteBrandAsync(int brandId)
    {
        var existingBrand = await _context.Brands.FindAsync(brandId);

        if (existingBrand == null)
            throw new NotFoundException(ExceptionMessages.BrandNotFound);

        _context.Brands.Remove(existingBrand);
        await _context.SaveChangesAsync();
        return existingBrand.AdaptToDto();
    }
}