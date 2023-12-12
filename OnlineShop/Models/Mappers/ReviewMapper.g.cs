using Mapster;
using Mapster.Utils;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs.OnlineShop.Domains;

namespace OnlineShop.Domains
{
    public static partial class ReviewMapper
    {
        private static TypeAdapterConfig TypeAdapterConfig1;
        
        public static ReviewDto AdaptToDto(this Review p1)
        {
            return p1 == null ? null : new ReviewDto()
            {
                Id = p1.Id,
                Rating = p1.Rating,
                Comment = p1.Comment,
                ProductId = p1.ProductId,
                UserId = p1.UserId,
                Title = p1.Title,
                CreatedAt = p1.CreatedAt,
                Product = p1.Product == null ? null : new ProductDto()
                {
                    Id = p1.Product.Id,
                    Name = p1.Product.Name,
                    Price = p1.Product.Price,
                    BrandId = p1.Product.BrandId,
                    CategoryId = p1.Product.CategoryId,
                    AverageRating = p1.Product.AverageRating,
                    Brand = p1.Product.Brand == null ? null : new BrandDto()
                    {
                        Id = p1.Product.Brand.Id,
                        Name = p1.Product.Brand.Name
                    },
                    Category = p1.Product.Category == null ? null : new CategoryDto()
                    {
                        Id = p1.Product.Category.Id,
                        Name = p1.Product.Category.Name,
                        ParentCategoryId = p1.Product.Category.ParentCategoryId,
                        ParentCategory = TypeAdapterConfig1.GetMapFunction<Category, CategoryDto>().Invoke(p1.Product.Category.ParentCategory)
                    }
                },
                User = p1.User == null ? null : new UserDto()
                {
                    Id = p1.User.Id,
                    Email = p1.User.Email,
                    Phone = p1.User.Phone,
                    FirstName = p1.User.FirstName,
                    LastName = p1.User.LastName,
                    Password = p1.User.Password,
                    UserType = Enum<UserType>.ToString(p1.User.UserType),
                    Address = p1.User.Address == null ? null : new AddressDto()
                    {
                        Id = p1.User.Address.Id,
                        AddressString = p1.User.Address.AddressString,
                        UserId = p1.User.Address.UserId,
                        User = TypeAdapterConfig1.GetMapFunction<User, UserDto>().Invoke(p1.User.Address.User)
                    }
                }
            };
        }
        public static ReviewDto AdaptTo(this Review p2, ReviewDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            ReviewDto result = p3 ?? new ReviewDto();
            
            result.Id = p2.Id;
            result.Rating = p2.Rating;
            result.Comment = p2.Comment;
            result.ProductId = p2.ProductId;
            result.UserId = p2.UserId;
            result.Title = p2.Title;
            result.CreatedAt = p2.CreatedAt;
            result.Product = p2.Product.AdaptToDto();
            result.User = p2.User.AdaptToDto();
            return result;
            
        }
        public static Review AdaptToReview(this ReviewAdd p14)
        {
            return p14 == null ? null : new Review()
            {
                Rating = p14.Rating,
                Comment = p14.Comment,
                ProductId = p14.ProductId,
                UserId = p14.UserId,
                Title = p14.Title,
                CreatedAt = p14.CreatedAt
            };
        }
        public static Review AdaptTo(this ReviewAdd p15, Review p16)
        {
            if (p15 == null)
            {
                return null;
            }
            Review result = p16 ?? new Review();
            
            result.Rating = p15.Rating;
            result.Comment = p15.Comment;
            result.ProductId = p15.ProductId;
            result.UserId = p15.UserId;
            result.Title = p15.Title;
            result.CreatedAt = p15.CreatedAt;
            return result;
            
        }
        public static Review AdaptToReview(this ReviewUpdate p17)
        {
            return p17 == null ? null : new Review()
            {
                Rating = p17.Rating,
                Comment = p17.Comment,
                ProductId = p17.ProductId,
                UserId = p17.UserId,
                Title = p17.Title,
                CreatedAt = p17.CreatedAt
            };
        }
        public static Review AdaptTo(this ReviewUpdate p18, Review p19)
        {
            if (p18 == null)
            {
                return null;
            }
            Review result = p19 ?? new Review();
            
            result.Rating = p18.Rating;
            result.Comment = p18.Comment;
            result.ProductId = p18.ProductId;
            result.UserId = p18.UserId;
            result.Title = p18.Title;
            result.CreatedAt = p18.CreatedAt;
            return result;
            
        }
    }
}