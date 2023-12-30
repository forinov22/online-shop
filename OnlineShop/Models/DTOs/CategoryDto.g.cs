namespace OnlineShop.Models.DTOs;

public record CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentCategoryId { get; set; }
}