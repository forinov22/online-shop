namespace OnlineShop.Models.DTOs.OnlineShop.Domains
{
    public partial class CategoryUpdate
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}