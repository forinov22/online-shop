namespace OnlineShop.Models.DTOs;

public record CartItemDto
{
    public int UserId { get; set; }
    public int ProductVersionId { get; set; }
    public int Quantity { get; set; }
    public ProductVersionDto ProductVersion { get; set; }
    public UserDto User { get; set; }
}