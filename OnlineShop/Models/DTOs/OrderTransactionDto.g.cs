namespace OnlineShop.Models.DTOs;

public record OrderTransactionDto
{
    public int Id { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string OrderTransactionStatus { get; set; }
    public int OrderId { get; set; }
    public OrderDto Order { get; set; }
}