using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domains;

public class Order
{
    [Key]
    public int Id { get; set; }

    public decimal Price { get; set; }

    public int UserId { get; set; }

    public int AddressId { get; set; }

    public DateTime CreatedAt { get; set; }

    public OrderStatus OrderStatus { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual ICollection<OrderTransaction> OrderTransactions { get; set; } = new List<OrderTransaction>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}