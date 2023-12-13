namespace OnlineShop.Models.DTOs;

public record CartItemUpdate
{
    public int ProductVersionId { get; set; }
    public int Quantity { get; set; }
}