namespace OnlineShop.Models.DTOs;

public record ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int BrandId { get; set; }
    public int CategoryId { get; set; }
    public double AverageRating { get; set; }
}