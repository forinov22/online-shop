using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domains;

public class Review
{
    [Key]
    public int Id { get; set; }

    public decimal Rating { get; set; }

    public string Comment { get; set; } = null!;

    public int ProductId { get; set; }

    public int UserId { get; set; }

    public string Title { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}