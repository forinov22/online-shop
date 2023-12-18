namespace OnlineShop.Models.DTOs;

public record AddressUpdate
{
    public string AddressString { get; set; }
    public int UserId { get; set; }
}