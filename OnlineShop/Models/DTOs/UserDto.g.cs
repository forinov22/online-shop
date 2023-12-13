namespace OnlineShop.Models.DTOs;

public record UserDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string UserType { get; set; }
    public AddressDto Address { get; set; }
}