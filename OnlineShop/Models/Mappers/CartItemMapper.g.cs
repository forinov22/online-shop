using Mapster;
using Mapster.Utils;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs.OnlineShop.Domains;

namespace OnlineShop.Domains
{
    public static partial class CartItemMapper
    {
        private static TypeAdapterConfig TypeAdapterConfig1;

        public static CartItemDto AdaptToDto(this CartItem p1)
        {
            return p1 == null
                ? null
                : new CartItemDto()
                {
                    UserId = p1.UserId,
                    ProductVersionId = p1.ProductVersionId,
                    Quantity = p1.Quantity,
                    ProductVersion = p1.ProductVersion == null
                        ? null
                        : new ProductVersionDto()
                        {
                            Id = p1.ProductVersion.Id,
                            Quantity = p1.ProductVersion.Quantity,
                            Sku = p1.ProductVersion.Sku,
                            ProductId = p1.ProductVersion.ProductId,
                            SizeId = p1.ProductVersion.SizeId,
                            ColorId = p1.ProductVersion.ColorId,
                            Color = p1.ProductVersion.Color == null
                                ? null
                                : new ColorDto()
                                {
                                    Id = p1.ProductVersion.Color.Id,
                                    Name = p1.ProductVersion.Color.Name
                                },
                            Product = p1.ProductVersion.Product == null
                                ? null
                                : new ProductDto()
                                {
                                    Id = p1.ProductVersion.Product.Id,
                                    Name = p1.ProductVersion.Product.Name,
                                    Price = p1.ProductVersion.Product.Price,
                                    BrandId = p1.ProductVersion.Product.BrandId,
                                    CategoryId = p1.ProductVersion.Product.CategoryId,
                                    AverageRating = p1.ProductVersion.Product.AverageRating,
                                    Brand = p1.ProductVersion.Product.Brand == null
                                        ? null
                                        : new BrandDto()
                                        {
                                            Id = p1.ProductVersion.Product.Brand.Id,
                                            Name = p1.ProductVersion.Product.Brand.Name
                                        },
                                    Category = p1.ProductVersion.Product.Category == null
                                        ? null
                                        : new CategoryDto()
                                        {
                                            Id = p1.ProductVersion.Product.Category.Id,
                                            Name = p1.ProductVersion.Product.Category.Name,
                                            ParentCategoryId = p1.ProductVersion.Product.Category.ParentCategoryId,
                                            ParentCategory = TypeAdapterConfig1.GetMapFunction<Category, CategoryDto>()
                                                .Invoke(p1.ProductVersion.Product.Category.ParentCategory)
                                        }
                                },
                            Size = p1.ProductVersion.Size == null
                                ? null
                                : new SizeDto()
                                {
                                    Id = p1.ProductVersion.Size.Id,
                                    Name = p1.ProductVersion.Size.Name
                                }
                        },
                    User = p1.User == null
                        ? null
                        : new UserDto()
                        {
                            Id = p1.User.Id,
                            Email = p1.User.Email,
                            Phone = p1.User.Phone,
                            FirstName = p1.User.FirstName,
                            LastName = p1.User.LastName,
                            Password = p1.User.Password,
                            UserType = Enum<UserType>.ToString(p1.User.UserType),
                            Address = p1.User.Address == null
                                ? null
                                : new AddressDto()
                                {
                                    Id = p1.User.Address.Id,
                                    AddressString = p1.User.Address.AddressString,
                                    UserId = p1.User.Address.UserId,
                                    User = TypeAdapterConfig1.GetMapFunction<User, UserDto>()
                                        .Invoke(p1.User.Address.User)
                                }
                        }
                };
        }

        public static CartItemDto AdaptTo(this CartItem p2, CartItemDto p3)
        {
            if (p2 == null)
            {
                return null;
            }

            CartItemDto result = p3 ?? new CartItemDto();

            result.UserId = p2.UserId;
            result.ProductVersionId = p2.ProductVersionId;
            result.Quantity = p2.Quantity;
            result.ProductVersion = funcMain1(p2.ProductVersion, result.ProductVersion);
            result.User = funcMain7(p2.User, result.User);
            return result;

        }

        public static CartItem AdaptToCartItem(this CartItemAdd p20)
        {
            return p20 == null
                ? null
                : new CartItem()
                {
                    ProductVersionId = p20.ProductVersionId,
                    Quantity = p20.Quantity
                };
        }

        public static CartItem AdaptTo(this CartItemAdd p21, CartItem p22)
        {
            if (p21 == null)
            {
                return null;
            }

            CartItem result = p22 ?? new CartItem();

            result.ProductVersionId = p21.ProductVersionId;
            result.Quantity = p21.Quantity;
            return result;

        }

        public static CartItem AdaptToCartItem(this CartItemUpdate p23)
        {
            return p23 == null
                ? null
                : new CartItem()
                {
                    ProductVersionId = p23.ProductVersionId,
                    Quantity = p23.Quantity
                };
        }

        public static CartItem AdaptTo(this CartItemUpdate p24, CartItem p25)
        {
            if (p24 == null)
            {
                return null;
            }

            CartItem result = p25 ?? new CartItem();

            result.ProductVersionId = p24.ProductVersionId;
            result.Quantity = p24.Quantity;
            return result;

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
}