//authservice
using Ott.Data;
using Ott.Dto;
using Ott.Models;

public class AuthService
{
    private readonly IUserRepository _userRepo;
    private readonly JwtService _jwtService;

    public AuthService(IUserRepository userRepo, JwtService jwtService)
    {
        _userRepo = userRepo;
        _jwtService = jwtService;
    }

    public async Task<string?> LoginAsync(LoginRequestDTO dto)
    {
        var user = await _userRepo.GetByEmailAsync(dto.Email);

        if (user == null)
            return null;

        bool valid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);

        if (!valid)
            return null;

       
        return _jwtService.GenerateToken(user.UserId, user.Email!);
    }

    public async Task<User> RegisterAsync(RegisterRequestDTO dto)
    {
        var user = new User
        {
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
        };

        return await _userRepo.AddAsync(user);
    }
}