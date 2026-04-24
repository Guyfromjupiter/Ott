using Ott.Models;

namespace Ott.Data
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user);
        Task<User?> GetByEmailAsync(String email);
        Task<User?> GetByIdAsync(int Id);
    }
}