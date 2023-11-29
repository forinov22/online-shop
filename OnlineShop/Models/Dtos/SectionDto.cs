namespace OnlineShop.Models.Dto;

using OnlineShop.Models;

public record SectionDto(int Id, string Name, IEnumerable<Category> Categories);

public record CreateSectionDto(string Name);

public record UpdateSectionDto(string Name);