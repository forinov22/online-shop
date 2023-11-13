using System;
using System.Collections.Generic;

namespace DbFirstApp.Models;

public class Size
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ProductVersion> ProductVersions { get; set; } = new List<ProductVersion>();
}
