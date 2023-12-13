namespace OnlineShop.Models.DTOs;

public record MediaUpdate
{
    public byte[] Bytes { get; set; }
    public string FileType { get; set; }
    public string FileName { get; set; }
    public int ProductId { get; set; }
}