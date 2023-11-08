﻿using System;
using System.Collections.Generic;

namespace DbFirstApp.Models;

public partial class Order
{
    public int Id { get; set; }

    public decimal Price { get; set; }

    public int UserId { get; set; }

    public int AddressId { get; set; }

    public DateTime CreatedAt { get; set; }

    public OrderStatus OrderStatus { get; set; }
    
    public virtual Address Address { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual OrderTransaction OrderTransaction { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
