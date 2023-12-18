namespace OnlineShop.Models.DTOs;

public record AddressAdd
{
    public string AddressString { get; set; }
    public int UserId { get; set; }
}