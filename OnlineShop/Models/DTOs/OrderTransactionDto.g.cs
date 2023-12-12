using System;
using OnlineShop.Models.DTOs;

namespace OnlineShop.Models.DTOs.OnlineShop.Domains
{
    public partial class OrderTransactionDto
    {
        public int Id { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string OrderTransactionStatus { get; set; }
        public int OrderId { get; set; }
        public OrderDto Order { get; set; }
    }
}