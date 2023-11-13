using System;
using System.Collections.Generic;

namespace DbFirstApp.Models;

public class OrderItem
{
    public int OrderId { get; set; }

    public int ProductVersionId { get; set; }

    public int Quantity { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual ProductVersion ProductVersion { get; set; } = null!;
}
