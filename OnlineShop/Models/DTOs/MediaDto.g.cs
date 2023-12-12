using OnlineShop.Models.DTOs;

namespace OnlineShop.Models.DTOs.OnlineShop.Domains
{
    public partial class MediaDto
    {
        public int Id { get; set; }
        public byte[] Bytes { get; set; }
        public string FileType { get; set; }
        public string FileName { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
    }
}