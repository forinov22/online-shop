namespace OnlineShop.Models.DTOs;

public record OrderItemUpdate
{
    public int ProductVersionId { get; set; }
    public int Quantity { get; set; }
}