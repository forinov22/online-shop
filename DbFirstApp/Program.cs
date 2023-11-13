
using DbFirstApp.Data;
using DbFirstApp.Models;
using Microsoft.EntityFrameworkCore;

var context = new OnlineShopContext();
context.Database.Migrate();

async Task<IEnumerable<Product>> GetAllProductsByBrand(OnlineShopContext ctx, string brandName)
{
    var brand = await ctx.Brands.FirstAsync(b => b.Name == brandName);
    var products = await ctx.Products.Where(p => p.BrandId == brand.Id).ToListAsync();
    return products;
}

async Task<IEnumerable<ProductVersion>> GetAllProductVersionsByProduct(OnlineShopContext ctx, string productName)
{
    var product = await ctx.Products.FirstAsync(p => p.Name == productName);
    var productVersions = await ctx.ProductVersions.Where(pv => pv.ProductId == product.Id).ToListAsync();
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

async Task<IEnumerable<Product>> GetAllProductsBySectionAndCategory(OnlineShopContext ctx, string sectionName, string categoryName)
{
    var section = await ctx.Sections.FirstAsync(s => s.Name == sectionName);
    var category = await ctx.Categories.Include(c => c.Sections).FirstAsync(c => c.Name == categoryName);

    var products = await ctx.Products.Where(p => p.CategoryId == category.Id && category.Sections.Contains(section)).ToListAsync();
    return products;
}

    