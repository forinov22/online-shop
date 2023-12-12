using Mapster;
using Mapster.Utils;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs.OnlineShop.Domains;

namespace OnlineShop.Domains
{
    public static partial class UserMapper
    {
        private static TypeAdapterConfig TypeAdapterConfig1;
        
        public static UserDto AdaptToDto(this User p1)
        {
            return p1 == null ? null : new UserDto()
            {
                Id = p1.Id,
                Email = p1.Email,
                Phone = p1.Phone,
                FirstName = p1.FirstName,
                LastName = p1.LastName,
                Password = p1.Password,
                UserType = Enum<UserType>.ToString(p1.UserType),
                Address = p1.Address == null ? null : new AddressDto()
                {
                    Id = p1.Address.Id,
                    AddressString = p1.Address.AddressString,
                    UserId = p1.Address.UserId,
                    User = TypeAdapterConfig1.GetMapFunction<User, UserDto>().Invoke(p1.Address.User)
                }
            };
        }
        public static UserDto AdaptTo(this User p2, UserDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            UserDto result = p3 ?? new UserDto();
            
            result.Id = p2.Id;
            result.Email = p2.Email;
            result.Phone = p2.Phone;
            result.FirstName = p2.FirstName;
            result.LastName = p2.LastName;
            result.Password = p2.Password;
            result.UserType = Enum<UserType>.ToString(p2.UserType);
            result.Address = p2.Address.AdaptToDto();
            return result;
            
        }
        public static User AdaptToUser(this UserAdd p6)
        {
            return p6 == null ? null : new User()
            {
                Email = p6.Email,
                Phone = p6.Phone,
                FirstName = p6.FirstName,
                LastName = p6.LastName,
                Password = p6.Password,
                UserType = p6.UserType == null ? UserType.Admin : Enum<UserType>.Parse(p6.UserType)
            };
        }
        public static User AdaptTo(this UserAdd p7, User p8)
        {
            if (p7 == null)
            {
                return null;
            }
            User result = p8 ?? new User();
            
            result.Email = p7.Email;
            result.Phone = p7.Phone;
            result.FirstName = p7.FirstName;
            result.LastName = p7.LastName;
            result.Password = p7.Password;
            result.UserType = p7.UserType == null ? UserType.Admin : Enum<UserType>.Parse(p7.UserType);
            return result;
            
        }
        public static User AdaptToUser(this UserUpdate p9)
        {
            return p9 == null ? null : new User()
            {
                Email = p9.Email,
                Phone = p9.Phone,
                FirstName = p9.FirstName,
                LastName = p9.LastName,
                Password = p9.Password,
                UserType = p9.UserType == null ? UserType.Admin : Enum<UserType>.Parse(p9.UserType)
            };
        }
        public static User AdaptTo(this UserUpdate p10, User p11)
        {
            if (p10 == null)
            {
                return null;
            }
            User result = p11 ?? new User();
            
            result.Email = p10.Email;
            result.Phone = p10.Phone;
            result.FirstName = p10.FirstName;
            result.LastName = p10.LastName;
            result.Password = p10.Password;
            result.UserType = p10.UserType == null ? UserType.Admin : Enum<UserType>.Parse(p10.UserType);
            return result;
            
        }
    }
}