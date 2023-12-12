using System;

namespace OnlineShop.Models.DTOs.OnlineShop.Domains
{
    public partial class OrderTransactionUpdate
    {
        public DateTime UpdatedAt { get; set; }
        public string OrderTransactionStatus { get; set; }
        public int OrderId { get; set; }
    }
}