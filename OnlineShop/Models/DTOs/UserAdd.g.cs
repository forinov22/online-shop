namespace OnlineShop.Models.DTOs.OnlineShop.Domains
{
    public partial class UserAdd
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
    }
}