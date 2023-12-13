namespace OnlineShop.Models.DTOs;

public record ProductVersionDto
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public string Sku { get; set; }
    public int ProductId { get; set; }
    public int SizeId { get; set; }
    public int ColorId { get; set; }
    public ColorDto Color { get; set; }
    public ProductDto Product { get; set; }
    public SizeDto Size { get; set; }
}