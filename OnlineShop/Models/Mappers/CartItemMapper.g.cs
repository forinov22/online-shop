using Mapster;
using Mapster.Utils;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs;

namespace OnlineShop.Models.Mappers;

public static partial class CartItemMapper
{
    private static TypeAdapterConfig TypeAdapterConfig = new();

    public static CartItemDto AdaptToDto(this CartItem entity)
    {
        return entity == null
            ? null
            : new CartItemDto()
            {
                UserId = entity.UserId,
                ProductVersionId = entity.ProductVersionId,
                Quantity = entity.Quantity,
                ProductVersion = entity.ProductVersion == null
                    ? null
                    : new ProductVersionDto()
                    {
                        Id = entity.ProductVersion.Id,
                        Quantity = entity.ProductVersion.Quantity,
                        Sku = entity.ProductVersion.Sku,
                        ProductId = entity.ProductVersion.ProductId,
                        SizeId = entity.ProductVersion.SizeId,
                        ColorId = entity.ProductVersion.ColorId,
                        Color = entity.ProductVersion.Color == null
                            ? null
                            : new ColorDto()
                            {
                                Id = entity.ProductVersion.Color.Id,
                                Name = entity.ProductVersion.Color.Name
                            },
                        Product = entity.ProductVersion.Product == null
                            ? null
                            : new ProductDto()
                            {
                                Id = entity.ProductVersion.Product.Id,
                                Name = entity.ProductVersion.Product.Name,
                                Price = entity.ProductVersion.Product.Price,
                                BrandId = entity.ProductVersion.Product.BrandId,
                                CategoryId = entity.ProductVersion.Product.CategoryId,
                                AverageRating = entity.ProductVersion.Product.AverageRating,
                                Brand = entity.ProductVersion.Product.Brand == null
                                    ? null
                                    : new BrandDto()
                                    {
                                        Id = entity.ProductVersion.Product.Brand.Id,
                                        Name = entity.ProductVersion.Product.Brand.Name
                                    },
                                Category = entity.ProductVersion.Product.Category == null
                                    ? null
                                    : new CategoryDto()
                                    {
                                        Id = entity.ProductVersion.Product.Category.Id,
                                        Name = entity.ProductVersion.Product.Category.Name,
                                        ParentCategoryId = entity.ProductVersion.Product.Category.ParentCategoryId,
                                        ParentCategory = TypeAdapterConfig.GetMapFunction<Category, CategoryDto>()
                                            .Invoke(entity.ProductVersion.Product.Category.ParentCategory)
                                    }
                            },
                        Size = entity.ProductVersion.Size == null
                            ? null
                            : new SizeDto()
                            {
                                Id = entity.ProductVersion.Size.Id,
                                Name = entity.ProductVersion.Size.Name
                            }
                    },
                User = entity.User == null
                    ? null
                    : new UserDto()
                    {
                        Id = entity.User.Id,
                        Email = entity.User.Email,
                        Phone = entity.User.Phone,
                        FirstName = entity.User.FirstName,
                        LastName = entity.User.LastName,
                        Password = entity.User.Password,
                        UserType = Enum<UserType>.ToString(entity.User.UserType),
                        Address = entity.User.Address == null
                            ? null
                            : new AddressDto()
                            {
                                Id = entity.User.Address.Id,
                                AddressString = entity.User.Address.AddressString,
                                UserId = entity.User.Address.UserId,
                                User = TypeAdapterConfig.GetMapFunction<User, UserDto>()
                                    .Invoke(entity.User.Address.User)
                            }
                    }
            };
    }

    public static CartItem AdaptToCartItem(this CartItemAdd dto)
    {
        return dto == null
            ? null
            : new CartItem()
            {
                ProductVersionId = dto.ProductVersionId,
                Quantity = dto.Quantity
            };
    }

    private static ProductVersionDto funcMain1(ProductVersion p4, ProductVersionDto p5)
    {
        if (p4 == null)
        {
            return null;
        }

        ProductVersionDto result = p5 ?? new ProductVersionDto();

        result.Id = p4.Id;
        result.Quantity = p4.Quantity;
        result.Sku = p4.Sku;
        result.ProductId = p4.ProductId;
        result.SizeId = p4.SizeId;
        result.ColorId = p4.ColorId;
        result.Color = p4.Color.AdaptToDto();
        result.Product = p4.Product.AdaptToDto();
        result.Size = p4.Size.AdaptToDto();
        return result;

    }

    private static UserDto funcMain7(User p16, UserDto p17)
    {
        if (p16 == null)
        {
            return null;
        }

        UserDto result = p17 ?? new UserDto();

        result.Id = p16.Id;
        result.Email = p16.Email;
        result.Phone = p16.Phone;
        result.FirstName = p16.FirstName;
        result.LastName = p16.LastName;
        result.Password = p16.Password;
        result.UserType = Enum<UserType>.ToString(p16.UserType);
        result.Address = p16.Address.AdaptToDto();
        return result;

    }
}