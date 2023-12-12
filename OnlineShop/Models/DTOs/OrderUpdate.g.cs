using System;

namespace OnlineShop.Models.DTOs.OnlineShop.Domains
{
    public partial class OrderUpdate
    {
        public decimal Price { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string OrderStatus { get; set; }
    }
}