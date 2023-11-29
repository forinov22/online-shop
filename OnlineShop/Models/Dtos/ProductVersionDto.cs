namespace OnlineShop.Models.Dto;

public record CreateSizeDto(string Name);

public record SizeDto(int id, string Name);

public record CreateColorDto(string Name);

public record ColorDto(int id, string Name);