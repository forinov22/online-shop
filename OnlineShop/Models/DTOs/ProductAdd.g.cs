namespace OnlineShop.Models.DTOs;

public record ProductAdd
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int BrandId { get; set; }
    public int CategoryId { get; set; }
    public double AverageRating { get; set; }
}