using OnlineShop.Models.DTOs;

namespace OnlineShop.Models.DTOs.OnlineShop.Domains
{
    public partial class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public double AverageRating { get; set; }
        public BrandDto Brand { get; set; }
        public CategoryDto Category { get; set; }
    }
}