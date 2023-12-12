using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domains;

public class OrderItem
{
    [Key]
    public int OrderId { get; set; }

    public int ProductVersionId { get; set; }

    public int Quantity { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual ProductVersion ProductVersion { get; set; } = null!;
}