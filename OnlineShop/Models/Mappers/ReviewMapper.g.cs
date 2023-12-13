using Mapster;
using Mapster.Utils;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs;

namespace OnlineShop.Models.Mappers;

public static partial class ReviewMapper
{
    private static TypeAdapterConfig TypeAdapterConfig;
        
    public static ReviewDto AdaptToDto(this Review entity)
    {
        return entity == null ? null : new ReviewDto()
        {
            Id = entity.Id,
            Rating = entity.Rating,
            Comment = entity.Comment,
            ProductId = entity.ProductId,
            UserId = entity.UserId,
            Title = entity.Title,
            CreatedAt = entity.CreatedAt,
            Product = entity.Product == null ? null : new ProductDto()
            {
                Id = entity.Product.Id,
                Name = entity.Product.Name,
                Price = entity.Product.Price,
                BrandId = entity.Product.BrandId,
                CategoryId = entity.Product.CategoryId,
                AverageRating = entity.Product.AverageRating,
                Brand = entity.Product.Brand == null ? null : new BrandDto()
                {
                    Id = entity.Product.Brand.Id,
                    Name = entity.Product.Brand.Name
                },
                Category = entity.Product.Category == null ? null : new CategoryDto()
                {
                    Id = entity.Product.Category.Id,
                    Name = entity.Product.Category.Name,
                    ParentCategoryId = entity.Product.Category.ParentCategoryId,
                    ParentCategory = TypeAdapterConfig.GetMapFunction<Category, CategoryDto>().Invoke(entity.Product.Category.ParentCategory)
                }
            },
            User = entity.User == null ? null : new UserDto()
            {
                Id = entity.User.Id,
                Email = entity.User.Email,
                Phone = entity.User.Phone,
                FirstName = entity.User.FirstName,
                LastName = entity.User.LastName,
                Password = entity.User.Password,
                UserType = Enum<UserType>.ToString(entity.User.UserType),
                Address = entity.User.Address == null ? null : new AddressDto()
                {
                    Id = entity.User.Address.Id,
                    AddressString = entity.User.Address.AddressString,
                    UserId = entity.User.Address.UserId,
                    User = TypeAdapterConfig.GetMapFunction<User, UserDto>().Invoke(entity.User.Address.User)
                }
            }
        };
    }
    
    public static Review AdaptToReview(this ReviewAdd dto)
    {
        return dto == null ? null : new Review()
        {
            Rating = dto.Rating,
            Comment = dto.Comment,
            ProductId = dto.ProductId,
            UserId = dto.UserId,
            Title = dto.Title,
            CreatedAt = dto.CreatedAt
        };
    }
}