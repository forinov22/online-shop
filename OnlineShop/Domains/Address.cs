using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domains;

public class Address
{
    [Key]
    public int Id { get; set; }

    public string AddressString { get; set; } = null!;

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}