namespace OnlineShop.Models.DTOs;

public record CartItemAdd
{
    public int ProductVersionId { get; set; }
    public int Quantity { get; set; }
}