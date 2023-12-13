namespace OnlineShop.Models.DTOs;

public record UserAdd
{
    public string Email { get; set; }
    public string Phone { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string UserType { get; set; }
}