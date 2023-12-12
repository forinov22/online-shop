namespace OnlineShop.Models.DTOs.OnlineShop.Domains
{
    public partial class MediaUpdate
    {
        public byte[] Bytes { get; set; }
        public string FileType { get; set; }
        public string FileName { get; set; }
        public int ProductId { get; set; }
    }
}