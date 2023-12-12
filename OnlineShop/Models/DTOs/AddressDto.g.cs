using OnlineShop.Models.DTOs;

namespace OnlineShop.Models.DTOs.OnlineShop.Domains
{
    public partial class AddressDto
    {
        public int Id { get; set; }
        public string AddressString { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
    }
}