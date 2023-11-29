﻿namespace OnlineShop.Models;

public class Color
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ProductVersion> ProductVersions { get; set; } = new List<ProductVersion>();
}
