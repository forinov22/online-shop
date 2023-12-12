namespace OnlineShop.Models.DTOs.OnlineShop.Domains
{
    public partial class CategoryAdd
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}