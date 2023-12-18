using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domains;

public class Media
{
    [Key]
    public int Id { get; set; }

    public byte[] Bytes { get; set; } = null!;

    public string FileType { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;
}