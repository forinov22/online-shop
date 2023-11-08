using System;
using System.Collections.Generic;

namespace DbFirstApp.Models;

public partial class Section
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
