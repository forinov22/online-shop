namespace OnlineShop.Models.DTOs;

public record AddressDto
{
    public int Id { get; set; }
    public string AddressString { get; set; }
    public int UserId { get; set; }
    public UserDto User { get; set; }
}