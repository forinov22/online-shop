using Mapster;
using Mapster.Utils;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs.OnlineShop.Domains;

namespace OnlineShop.Domains
{
    public static partial class OrderMapper
    {
        private static TypeAdapterConfig TypeAdapterConfig1;
        
        public static OrderDto AdaptToDto(this Order p1)
        {
            return p1 == null ? null : new OrderDto()
            {
                Id = p1.Id,
                Price = p1.Price,
                UserId = p1.UserId,
                AddressId = p1.AddressId,
                CreatedAt = p1.CreatedAt,
                OrderStatus = Enum<OrderStatus>.ToString(p1.OrderStatus),
                Address = p1.Address == null ? null : new AddressDto()
                {
                    Id = p1.Address.Id,
                    AddressString = p1.Address.AddressString,
                    UserId = p1.Address.UserId,
                    User = p1.Address.User == null ? null : new UserDto()
                    {
                        Id = p1.Address.User.Id,
                        Email = p1.Address.User.Email,
                        Phone = p1.Address.User.Phone,
                        FirstName = p1.Address.User.FirstName,
                        LastName = p1.Address.User.LastName,
                        Password = p1.Address.User.Password,
                        UserType = Enum<UserType>.ToString(p1.Address.User.UserType),
                        Address = TypeAdapterConfig1.GetMapFunction<Address, AddressDto>().Invoke(p1.Address.User.Address)
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
        public static OrderDto AdaptTo(this Order p2, OrderDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            OrderDto result = p3 ?? new OrderDto();
            
            result.Id = p2.Id;
            result.Price = p2.Price;
            result.UserId = p2.UserId;
            result.AddressId = p2.AddressId;
            result.CreatedAt = p2.CreatedAt;
            result.OrderStatus = Enum<OrderStatus>.ToString(p2.OrderStatus);
            result.Address = p2.Address.AdaptToDto();
            result.User = p2.User.AdaptToDto();
            return result;
            
        }
        public static Order AdaptToOrder(this OrderAdd p12)
        {
            return p12 == null ? null : new Order()
            {
                Price = p12.Price,
                UserId = p12.UserId,
                AddressId = p12.AddressId,
                CreatedAt = p12.CreatedAt,
                OrderStatus = p12.OrderStatus == null ? OrderStatus.Processing : Enum<OrderStatus>.Parse(p12.OrderStatus)
            };
        }
        public static Order AdaptTo(this OrderAdd p13, Order p14)
        {
            if (p13 == null)
            {
                return null;
            }
            Order result = p14 ?? new Order();
            
            result.Price = p13.Price;
            result.UserId = p13.UserId;
            result.AddressId = p13.AddressId;
            result.CreatedAt = p13.CreatedAt;
            result.OrderStatus = p13.OrderStatus == null ? OrderStatus.Processing : Enum<OrderStatus>.Parse(p13.OrderStatus);
            return result;
            
        }
        public static Order AdaptToOrder(this OrderUpdate p15)
        {
            return p15 == null ? null : new Order()
            {
                Price = p15.Price,
                UserId = p15.UserId,
                AddressId = p15.AddressId,
                CreatedAt = p15.CreatedAt,
                OrderStatus = p15.OrderStatus == null ? OrderStatus.Processing : Enum<OrderStatus>.Parse(p15.OrderStatus)
            };
        }
        public static Order AdaptTo(this OrderUpdate p16, Order p17)
        {
            if (p16 == null)
            {
                return null;
            }
            Order result = p17 ?? new Order();
            
            result.Price = p16.Price;
            result.UserId = p16.UserId;
            result.AddressId = p16.AddressId;
            result.CreatedAt = p16.CreatedAt;
            result.OrderStatus = p16.OrderStatus == null ? OrderStatus.Processing : Enum<OrderStatus>.Parse(p16.OrderStatus);
            return result;
            
        }
    }
}