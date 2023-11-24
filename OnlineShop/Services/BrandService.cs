using DbFirstApp.Data;
using OnlineShop.Models;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Services;

public interface IBrandService {
    Task<IEnumerable<Brand>> GetAllBrandsAsync();
    Task<Brand?> GetBrandByIdAsync(int id);
    Task<Brand> CreateBrandAsync(Brand brand);
    Task<Brand?> UpdateBrandAsync(int id, Brand updatedBrand);
    Task<bool> DeleteBrandAsync(int id);
};

public class BrandService : IBrandService
{
    private readonly OnlineShopContext _ctx;

    public BrandService(OnlineShopContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<Brand> CreateBrandAsync(Brand brand)
    {
        await _ctx.Brands.AddAsync(brand);
        await _ctx.SaveChangesAsync();
        return brand;
    }

    public async Task<bool> DeleteBrandAsync(int id)
    {
        var existingBrand = await _ctx.Brands.FindAsync(id);

        if (existingBrand == null) 
            return false;

        _ctx.Brands.Remove(existingBrand);
        await _ctx.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Brand>> GetAllBrandsAsync()
    {
        return await _ctx.Brands.ToListAsync();
    }

    public async Task<Brand?> GetBrandByIdAsync(int id)
    {
        return await _ctx.Brands.FindAsync(id);
    }

    public async Task<Brand?> UpdateBrandAsync(int id, Brand updatedBrand)
    {
        var brand = await _ctx.Brands.FindAsync(id);

        if (brand != null) {
            brand.Name = updatedBrand.Name;
            await _ctx.SaveChangesAsync();
        }

        /*
            or 
            _context.Entry(brand).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            which approach is better?
        */

        return brand;
    }
}
