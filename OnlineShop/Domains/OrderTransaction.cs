using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domains;

public class OrderTransaction
{
    [Key]
    public int Id { get; set; }

    public DateTime UpdatedAt { get; set; }

    public OrderStatus OrderTransactionStatus { get; set; }

    public int OrderId { get; set; }

    public virtual Order Order { get; set; } = null!;
}