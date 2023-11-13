using System;
using System.Collections.Generic;

namespace DbFirstApp.Models;

public class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? ParentCategoryId { get; set; }

    public virtual Category? ParentCategory { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}
