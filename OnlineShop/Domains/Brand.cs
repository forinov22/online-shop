using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Mapster;

namespace OnlineShop.Domains;

public class Brand
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}