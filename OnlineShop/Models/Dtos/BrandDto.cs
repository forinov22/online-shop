using OnlineShop.Models;

public record BrandDto(int Id, string Name, IEnumerable<Product> Products);

public record CreateBrandDto(string Name);

public record UpdateBrandDto(string Name);