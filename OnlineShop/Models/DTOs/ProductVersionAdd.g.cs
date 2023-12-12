namespace OnlineShop.Models.DTOs.OnlineShop.Domains
{
    public partial class ProductVersionAdd
    {
        public int Quantity { get; set; }
        public string Sku { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
    }
}