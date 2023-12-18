using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domains;

public class Section
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}