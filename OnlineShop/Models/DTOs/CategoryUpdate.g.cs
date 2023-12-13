namespace OnlineShop.Models.DTOs;

public record CategoryUpdate
{
    public string Name { get; set; }
    public int? ParentCategoryId { get; set; }
}