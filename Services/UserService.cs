using Ott.Data;
using Ott.Dto;
using Ott.Models;

namespace Ott.Services
{
public class UserService
{
    private readonly IUserRepository _userRepo;

    public UserService(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    public async Task<User> RegisterUser(RegisterRequestDTO dto)
    {
        var existing = await _userRepo.GetByEmailAsync(dto.Email);
        if (existing != null)
            throw new Exception("User already exists");

        var user = new User
        {
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
        };

        return await _userRepo.AddAsync(user);
    }

    public async Task<User?> ValidateUser(LoginRequestDTO dto)
    {
        var user = await _userRepo.GetByEmailAsync(dto.Email);
        if (user == null) return null;

        return BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash)
            ? user
            : null;
    }

    public async Task<User?> GetUserById(int userId)
    {
        return await _userRepo.GetByIdAsync(userId);
    }
}
}