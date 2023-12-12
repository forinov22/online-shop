using System;
using OnlineShop.Models.DTOs;

namespace OnlineShop.Models.DTOs.OnlineShop.Domains
{
    public partial class ReviewDto
    {
        public int Id { get; set; }
        public decimal Rating { get; set; }
        public string Comment { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public ProductDto Product { get; set; }
        public UserDto User { get; set; }
    }
}