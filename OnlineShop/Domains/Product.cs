using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domains;

public class Product
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int BrandId { get; set; }

    public int CategoryId { get; set; }

    public double AverageRating { get; set; }

    public virtual ICollection<Media> Media { get; set; } = new List<Media>();

    public virtual Brand Brand { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<ProductVersion> ProductVersions { get; set; } = new List<ProductVersion>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}