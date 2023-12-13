namespace OnlineShop.Models.DTOs;

public record OrderItemAdd
{
    public int ProductVersionId { get; set; }
    public int Quantity { get; set; }
}