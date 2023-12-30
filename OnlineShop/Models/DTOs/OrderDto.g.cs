namespace OnlineShop.Models.DTOs;

public record OrderDto
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public int UserId { get; set; }
    public int AddressId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string OrderStatus { get; set; }
}