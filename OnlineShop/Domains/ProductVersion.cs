using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domains;

public class ProductVersion
{
    [Key]
    public int Id { get; set; }

    public int Quantity { get; set; }

    public string Sku { get; set; } = null!;

    public int ProductId { get; set; }

    public int SizeId { get; set; }

    public int ColorId { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Color Color { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Size Size { get; set; } = null!;
}