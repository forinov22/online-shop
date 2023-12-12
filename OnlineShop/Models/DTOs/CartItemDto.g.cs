using OnlineShop.Models.DTOs;

namespace OnlineShop.Models.DTOs.OnlineShop.Domains
{
    public partial class CartItemDto
    {
        public int UserId { get; set; }
        public int ProductVersionId { get; set; }
        public int Quantity { get; set; }
        public ProductVersionDto ProductVersion { get; set; }
        public UserDto User { get; set; }
    }
}