using Mapster;
using Mapster.Utils;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs.OnlineShop.Domains;

namespace OnlineShop.Domains
{
    public static partial class OrderTransactionMapper
    {
        private static TypeAdapterConfig TypeAdapterConfig1;
        
        public static OrderTransactionDto AdaptToDto(this OrderTransaction p1)
        {
            return p1 == null ? null : new OrderTransactionDto()
            {
                Id = p1.Id,
                UpdatedAt = p1.UpdatedAt,
                OrderTransactionStatus = Enum<OrderStatus>.ToString(p1.OrderTransactionStatus),
                OrderId = p1.OrderId,
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
                }
            };
        }
        public static OrderTransactionDto AdaptTo(this OrderTransaction p2, OrderTransactionDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            OrderTransactionDto result = p3 ?? new OrderTransactionDto();
            
            result.Id = p2.Id;
            result.UpdatedAt = p2.UpdatedAt;
            result.OrderTransactionStatus = Enum<OrderStatus>.ToString(p2.OrderTransactionStatus);
            result.OrderId = p2.OrderId;
            result.Order = p2.Order.AdaptToDto();
            return result;
            
        }
        public static OrderTransaction AdaptToOrderTransaction(this OrderTransactionAdd p14)
        {
            return p14 == null ? null : new OrderTransaction()
            {
                UpdatedAt = p14.UpdatedAt,
                OrderTransactionStatus = p14.OrderTransactionStatus == null ? OrderStatus.Processing : Enum<OrderStatus>.Parse(p14.OrderTransactionStatus),
                OrderId = p14.OrderId
            };
        }
        public static OrderTransaction AdaptTo(this OrderTransactionAdd p15, OrderTransaction p16)
        {
            if (p15 == null)
            {
                return null;
            }
            OrderTransaction result = p16 ?? new OrderTransaction();
            
            result.UpdatedAt = p15.UpdatedAt;
            result.OrderTransactionStatus = p15.OrderTransactionStatus == null ? OrderStatus.Processing : Enum<OrderStatus>.Parse(p15.OrderTransactionStatus);
            result.OrderId = p15.OrderId;
            return result;
            
        }
        public static OrderTransaction AdaptToOrderTransaction(this OrderTransactionUpdate p17)
        {
            return p17 == null ? null : new OrderTransaction()
            {
                UpdatedAt = p17.UpdatedAt,
                OrderTransactionStatus = p17.OrderTransactionStatus == null ? OrderStatus.Processing : Enum<OrderStatus>.Parse(p17.OrderTransactionStatus),
                OrderId = p17.OrderId
            };
        }
        public static OrderTransaction AdaptTo(this OrderTransactionUpdate p18, OrderTransaction p19)
        {
            if (p18 == null)
            {
                return null;
            }
            OrderTransaction result = p19 ?? new OrderTransaction();
            
            result.UpdatedAt = p18.UpdatedAt;
            result.OrderTransactionStatus = p18.OrderTransactionStatus == null ? OrderStatus.Processing : Enum<OrderStatus>.Parse(p18.OrderTransactionStatus);
            result.OrderId = p18.OrderId;
            return result;
            
        }
    }
}