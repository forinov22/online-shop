namespace OnlineShop.Models.DTOs;

public record MediaDto
{
    public int Id { get; set; }
    public string FileType { get; set; }
    public string FileName { get; set; }
    public int ProductId { get; set; }
    public ProductDto Product { get; set; }
}