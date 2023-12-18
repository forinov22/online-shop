namespace OnlineShop.Models.DTOs;

public record OrderTransactionAdd
{
    public DateTime UpdatedAt { get; set; }
    public string OrderTransactionStatus { get; set; }
    public int OrderId { get; set; }
}