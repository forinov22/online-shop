
using DbFirstApp.Data;
using DbFirstApp.Models;
using Microsoft.EntityFrameworkCore;

var context = new OnlineShopContext();
context.Database.Migrate();

IEnumerable<Product> getAllProductsOfSelectedBrand(OnlineShopContext ctx, string brandName)
{
    var brand = ctx.Brands.First(b => b.Name == brandName);
    var products = ctx.Products.Where(p => p.BrandId == brand.Id);
    return products;
}

IEnumerable<ProductVersion> getAllProductVersionsOfSelectedProduct(OnlineShopContext ctx, string productName)
{
    var product = ctx.Products.First(p => p.Name == productName);
    var productVersions = ctx.ProductVersions.Where(pv => pv.ProductId == product.Id);
    return productVersions;
}

IDictionary<Brand, int> getAllBrandsWithNumberOfTheirProducts(OnlineShopContext ctx)
{
    var brands = ctx.Brands.Include(b => b.Products).ToList();
    var d = new Dictionary<Brand, int>();
    foreach (var brand in brands)
    {
        d.Add(brand, brand.Products.Count);
    }
    return d;
}

IEnumerable<Product> getAllProductsBySectionAndCategory(OnlineShopContext ctx, string sectionName, string categoryName)
{
    var section = ctx.Sections.First(s => s.Name == sectionName);
    var category = ctx.Categories.Include(c => c.Sections).First(c => c.Name == categoryName);

    var products = ctx.Products.Where(p => p.CategoryId == category.Id && category.Sections.Contains(section));
    return products;
}

    