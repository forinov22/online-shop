using Mapster;
using Mapster.Utils;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Domains;
using OnlineShop.Exceptions;
using OnlineShop.Models.DTOs;
using OnlineShop.Models.Mappers;

namespace OnlineShop.Services;

public interface IUserService
{
    Task<UserDto> GetUserByIdAsync(int userId);
    Task<UserDto> CreateUserAsync(UserAdd dto);
    Task<UserDto> UpdateUserAsync(int userId, UserUpdate dto);
    Task<UserDto> DeleteUserAsync(int userId);
}

public class UserService : IUserService
{
    private readonly OnlineShopContext _context;

    public UserService(OnlineShopContext context)
    {
        _context = context;
    }

    public async Task<UserDto> GetUserByIdAsync(int userId)
    {
        var user = await _context.Users.ProjectToType<UserDto>()
            .FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null)
            throw new NotFoundException(ExceptionMessages.UserNotFound);

        return user;
    }

    public async Task<UserDto> CreateUserAsync(UserAdd dto)
    {
        var candidate = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);

        if (candidate != null)
            throw new AuthorizationException(ExceptionMessages.EmailIsTaken);

        var user = dto.AdaptToUser();
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user.AdaptToDto();
    }

    public async Task<UserDto> UpdateUserAsync(int userId, UserUpdate dto)
    {
        var existingUser = await _context.Users.FindAsync(userId);

        if (existingUser == null)
            throw new NotFoundException(ExceptionMessages.UserNotFound);

        var sameEmail = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == dto.Email);

        if (sameEmail != null)
            throw new AuthorizationException(ExceptionMessages.EmailIsTaken);

        existingUser.Email = dto.Email;
        existingUser.Phone = dto.Phone;
        existingUser.FirstName = dto.FirstName;
        existingUser.LastName = dto.LastName;
        existingUser.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);
        existingUser.UserType = Enum<UserType>.Parse(dto.UserType);

        await _context.SaveChangesAsync();
        return existingUser.AdaptToDto();
    }

    public async Task<UserDto> DeleteUserAsync(int userId)
    {
        var existingUser = await _context.Users.FindAsync(userId);

        if (existingUser == null)
            throw new NotFoundException(ExceptionMessages.UserNotFound);

        _context.Users.Remove(existingUser);
        await _context.SaveChangesAsync();
        return existingUser.AdaptToDto();
    }
}