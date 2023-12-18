namespace OnlineShop.Models.DTOs;

public record MediaAdd
{
    public IFormFile File { get; set; }
    public int ProductId { get; set; }
}