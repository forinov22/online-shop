using Mapster;
using Mapster.Utils;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs.OnlineShop.Domains;

namespace OnlineShop.Domains
{
    public static partial class OrderItemMapper
    {
        private static TypeAdapterConfig TypeAdapterConfig1;
        
        public static OrderItemDto AdaptToDto(this OrderItem p1)
        {
            return p1 == null ? null : new OrderItemDto()
            {
                OrderId = p1.OrderId,
                ProductVersionId = p1.ProductVersionId,
                Quantity = p1.Quantity,
                Order = p1.Order == null ? null : new OrderDto()
                {
                    Id = p1.Order.Id,
                    Price = p1.Order.Price,
                    UserId = p1.Order.UserId,
                    AddressId = p1.Order.AddressId,
                    CreatedAt = p1.Order.CreatedAt,
                    OrderStatus = Enum<OrderStatus>.ToString(p1.Order.OrderStatus),
                    Address = p1.Order.Address == null ? null : new AddressDto()
                    {
                        Id = p1.Order.Address.Id,
                        AddressString = p1.Order.Address.AddressString,
                        UserId = p1.Order.Address.UserId,
                        User = p1.Order.Address.User == null ? null : new UserDto()
                        {
                            Id = p1.Order.Address.User.Id,
                            Email = p1.Order.Address.User.Email,
                            Phone = p1.Order.Address.User.Phone,
                            FirstName = p1.Order.Address.User.FirstName,
                            LastName = p1.Order.Address.User.LastName,
                            Password = p1.Order.Address.User.Password,
                            UserType = Enum<UserType>.ToString(p1.Order.Address.User.UserType),
                            Address = TypeAdapterConfig1.GetMapFunction<Address, AddressDto>().Invoke(p1.Order.Address.User.Address)
                        }
                    },
                    User = p1.Order.User == null ? null : new UserDto()
                    {
                        Id = p1.Order.User.Id,
                        Email = p1.Order.User.Email,
                        Phone = p1.Order.User.Phone,
                        FirstName = p1.Order.User.FirstName,
                        LastName = p1.Order.User.LastName,
                        Password = p1.Order.User.Password,
                        UserType = Enum<UserType>.ToString(p1.Order.User.UserType),
                        Address = p1.Order.User.Address == null ? null : new AddressDto()
                        {
                            Id = p1.Order.User.Address.Id,
                            AddressString = p1.Order.User.Address.AddressString,
                            UserId = p1.Order.User.Address.UserId,
                            User = TypeAdapterConfig1.GetMapFunction<User, UserDto>().Invoke(p1.Order.User.Address.User)
                        }
                    }
                },
                ProductVersion = p1.ProductVersion == null ? null : new ProductVersionDto()
                {
                    Id = p1.ProductVersion.Id,
                    Quantity = p1.ProductVersion.Quantity,
                    Sku = p1.ProductVersion.Sku,
                    ProductId = p1.ProductVersion.ProductId,
                    SizeId = p1.ProductVersion.SizeId,
                    ColorId = p1.ProductVersion.ColorId,
                    Color = p1.ProductVersion.Color == null ? null : new ColorDto()
                    {
                        Id = p1.ProductVersion.Color.Id,
                        Name = p1.ProductVersion.Color.Name
                    },
                    Product = p1.ProductVersion.Product == null ? null : new ProductDto()
                    {
                        Id = p1.ProductVersion.Product.Id,
                        Name = p1.ProductVersion.Product.Name,
                        Price = p1.ProductVersion.Product.Price,
                        BrandId = p1.ProductVersion.Product.BrandId,
                        CategoryId = p1.ProductVersion.Product.CategoryId,
                        AverageRating = p1.ProductVersion.Product.AverageRating,
                        Brand = p1.ProductVersion.Product.Brand == null ? null : new BrandDto()
                        {
                            Id = p1.ProductVersion.Product.Brand.Id,
                            Name = p1.ProductVersion.Product.Brand.Name
                        },
                        Category = p1.ProductVersion.Product.Category == null ? null : new CategoryDto()
                        {
                            Id = p1.ProductVersion.Product.Category.Id,
                            Name = p1.ProductVersion.Product.Category.Name,
                            ParentCategoryId = p1.ProductVersion.Product.Category.ParentCategoryId,
                            ParentCategory = TypeAdapterConfig1.GetMapFunction<Category, CategoryDto>().Invoke(p1.ProductVersion.Product.Category.ParentCategory)
                        }
                    },
                    Size = p1.ProductVersion.Size == null ? null : new SizeDto()
                    {
                        Id = p1.ProductVersion.Size.Id,
                        Name = p1.ProductVersion.Size.Name
                    }
                }
            };
        }
        public static OrderItemDto AdaptTo(this OrderItem p2, OrderItemDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            OrderItemDto result = p3 ?? new OrderItemDto();
            
            result.OrderId = p2.OrderId;
            result.ProductVersionId = p2.ProductVersionId;
            result.Quantity = p2.Quantity;
            result.Order = p2.Order.AdaptToDto();
            result.ProductVersion = p2.ProductVersion.AdaptToDto();
            return result;
            
        }
        public static OrderItem AdaptToOrderItem(this OrderItemAdd p26)
        {
            return p26 == null ? null : new OrderItem()
            {
                ProductVersionId = p26.ProductVersionId,
                Quantity = p26.Quantity
            };
        }
        public static OrderItem AdaptTo(this OrderItemAdd p27, OrderItem p28)
        {
            if (p27 == null)
            {
                return null;
            }
            OrderItem result = p28 ?? new OrderItem();
            
            result.ProductVersionId = p27.ProductVersionId;
            result.Quantity = p27.Quantity;
            return result;
            
        }
        public static OrderItem AdaptToOrderItem(this OrderItemUpdate p29)
        {
            return p29 == null ? null : new OrderItem()
            {
                ProductVersionId = p29.ProductVersionId,
                Quantity = p29.Quantity
            };
        }
        public static OrderItem AdaptTo(this OrderItemUpdate p30, OrderItem p31)
        {
            if (p30 == null)
            {
                return null;
            }
            OrderItem result = p31 ?? new OrderItem();
            
            result.ProductVersionId = p30.ProductVersionId;
            result.Quantity = p30.Quantity;
            return result;
            
        }
    }
}