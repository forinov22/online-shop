using System;
using OnlineShop.Models.DTOs;

namespace OnlineShop.Models.DTOs.OnlineShop.Domains
{
    public partial class OrderDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string OrderStatus { get; set; }
        public AddressDto Address { get; set; }
        public UserDto User { get; set; }
    }
}