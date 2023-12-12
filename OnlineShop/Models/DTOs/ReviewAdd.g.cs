using System;

namespace OnlineShop.Models.DTOs.OnlineShop.Domains
{
    public partial class ReviewAdd
    {
        public decimal Rating { get; set; }
        public string Comment { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}