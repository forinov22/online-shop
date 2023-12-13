using Mapster;
using Mapster.Utils;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs;

namespace OnlineShop.Models.Mappers;

public static partial class OrderItemMapper
{
    private static TypeAdapterConfig TypeAdapterConfig;
        
    public static OrderItemDto AdaptToDto(this OrderItem entity)
    {
        return entity == null ? null : new OrderItemDto()
        {
            OrderId = entity.OrderId,
            ProductVersionId = entity.ProductVersionId,
            Quantity = entity.Quantity,
            Order = entity.Order == null ? null : new OrderDto()
            {
                Id = entity.Order.Id,
                Price = entity.Order.Price,
                UserId = entity.Order.UserId,
                AddressId = entity.Order.AddressId,
                CreatedAt = entity.Order.CreatedAt,
                OrderStatus = Enum<OrderStatus>.ToString(entity.Order.OrderStatus),
                Address = entity.Order.Address == null ? null : new AddressDto()
                {
                    Id = entity.Order.Address.Id,
                    AddressString = entity.Order.Address.AddressString,
                    UserId = entity.Order.Address.UserId,
                    User = entity.Order.Address.User == null ? null : new UserDto()
                    {
                        Id = entity.Order.Address.User.Id,
                        Email = entity.Order.Address.User.Email,
                        Phone = entity.Order.Address.User.Phone,
                        FirstName = entity.Order.Address.User.FirstName,
                        LastName = entity.Order.Address.User.LastName,
                        Password = entity.Order.Address.User.Password,
                        UserType = Enum<UserType>.ToString(entity.Order.Address.User.UserType),
                        Address = TypeAdapterConfig.GetMapFunction<Address, AddressDto>().Invoke(entity.Order.Address.User.Address)
                    }
                },
                User = entity.Order.User == null ? null : new UserDto()
                {
                    Id = entity.Order.User.Id,
                    Email = entity.Order.User.Email,
                    Phone = entity.Order.User.Phone,
                    FirstName = entity.Order.User.FirstName,
                    LastName = entity.Order.User.LastName,
                    Password = entity.Order.User.Password,
                    UserType = Enum<UserType>.ToString(entity.Order.User.UserType),
                    Address = entity.Order.User.Address == null ? null : new AddressDto()
                    {
                        Id = entity.Order.User.Address.Id,
                        AddressString = entity.Order.User.Address.AddressString,
                        UserId = entity.Order.User.Address.UserId,
                        User = TypeAdapterConfig.GetMapFunction<User, UserDto>().Invoke(entity.Order.User.Address.User)
                    }
                }
            },
            ProductVersion = entity.ProductVersion == null ? null : new ProductVersionDto()
            {
                Id = entity.ProductVersion.Id,
                Quantity = entity.ProductVersion.Quantity,
                Sku = entity.ProductVersion.Sku,
                ProductId = entity.ProductVersion.ProductId,
                SizeId = entity.ProductVersion.SizeId,
                ColorId = entity.ProductVersion.ColorId,
                Color = entity.ProductVersion.Color == null ? null : new ColorDto()
                {
                    Id = entity.ProductVersion.Color.Id,
                    Name = entity.ProductVersion.Color.Name
                },
                Product = entity.ProductVersion.Product == null ? null : new ProductDto()
                {
                    Id = entity.ProductVersion.Product.Id,
                    Name = entity.ProductVersion.Product.Name,
                    Price = entity.ProductVersion.Product.Price,
                    BrandId = entity.ProductVersion.Product.BrandId,
                    CategoryId = entity.ProductVersion.Product.CategoryId,
                    AverageRating = entity.ProductVersion.Product.AverageRating,
                    Brand = entity.ProductVersion.Product.Brand == null ? null : new BrandDto()
                    {
                        Id = entity.ProductVersion.Product.Brand.Id,
                        Name = entity.ProductVersion.Product.Brand.Name
                    },
                    Category = entity.ProductVersion.Product.Category == null ? null : new CategoryDto()
                    {
                        Id = entity.ProductVersion.Product.Category.Id,
                        Name = entity.ProductVersion.Product.Category.Name,
                        ParentCategoryId = entity.ProductVersion.Product.Category.ParentCategoryId,
                        ParentCategory = TypeAdapterConfig.GetMapFunction<Category, CategoryDto>().Invoke(entity.ProductVersion.Product.Category.ParentCategory)
                    }
                },
                Size = entity.ProductVersion.Size == null ? null : new SizeDto()
                {
                    Id = entity.ProductVersion.Size.Id,
                    Name = entity.ProductVersion.Size.Name
                }
            }
        };
    }
    
    public static OrderItem AdaptToOrderItem(this OrderItemAdd dto)
    {
        return dto == null ? null : new OrderItem()
        {
            ProductVersionId = dto.ProductVersionId,
            Quantity = dto.Quantity
        };
    }
}