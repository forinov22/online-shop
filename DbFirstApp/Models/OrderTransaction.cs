using System;
using System.Collections.Generic;

namespace DbFirstApp.Models;

public class OrderTransaction
{
    public int Id { get; set; }

    public DateTime UpdatedAt { get; set; }

    public OrderStatus OrderTransactionStatus { get; set; }

    public int OrderId { get; set; }
    
    public virtual Order Order { get; set; } = null!;
}
