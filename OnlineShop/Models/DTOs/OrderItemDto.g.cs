namespace OnlineShop.Models.DTOs;

public record OrderItemDto
{
    public int OrderId { get; set; }
    public int ProductVersionId { get; set; }
    public int Quantity { get; set; }
    public OrderDto Order { get; set; }
    public ProductVersionDto ProductVersion { get; set; }
}