using DbFirstApp.Data;
using DbFirstApp.Models;
using Microsoft.EntityFrameworkCore;
using OnlineShop;

public class Program
{
    static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    async Task<IEnumerable<Product>> GetAllProductsByBrand(OnlineShopContext ctx, int brandId)
    {
        var products = await ctx.Products.Where(p => p.BrandId == brandId).ToListAsync();
        return products;
    }

    async Task<IEnumerable<ProductVersion>> GetAllProductVersionsByProduct(OnlineShopContext ctx, int productId)
    {
        var productVersions = await ctx.ProductVersions.Where(pv => pv.ProductId == productId).ToListAsync();
        return productVersions;
    }

    async Task<IDictionary<Brand, int>> GetAllBrandsProductCount(OnlineShopContext ctx)
    {
        var brands = await ctx.Brands.Include(b => b.Products).ToListAsync();
        var d = new Dictionary<Brand, int>();
        foreach (var brand in brands)
        {
            d.Add(brand, brand.Products.Count);
        }
        return d;
    }

    async Task<IEnumerable<Product>> GetAllProductsBySectionAndCategory(OnlineShopContext ctx, int sectionId, int categoryId)
    {
        var products = ctx.Products
            .Where(p => p.CategoryId == categoryId)
            .Include(p => p.Category.Sections);

        var section = products.First().Category.Sections.Single(s => s.Id == sectionId);
        return section == null ? Enumerable.Empty<Product>() : products;
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
}; 