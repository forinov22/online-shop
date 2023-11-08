using System;
using System.Collections.Generic;

namespace DbFirstApp.Models;

public partial class CartItem
{
    public int UserId { get; set; }

    public int ProductVersionId { get; set; }

    public int Quantity { get; set; }

    public virtual ProductVersion ProductVersion { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
