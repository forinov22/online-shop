namespace OnlineShop.Models.DTOs;

public record CategoryAdd
{
    public string Name { get; set; }
    public int? ParentCategoryId { get; set; }
}