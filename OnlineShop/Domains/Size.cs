using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domains;

public class Size
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ProductVersion> ProductVersions { get; set; } = new List<ProductVersion>();
}