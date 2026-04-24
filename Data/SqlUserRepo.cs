using Microsoft.EntityFrameworkCore;
using Ott.Models;

namespace Ott.Data
{
    public class SqlUserRepo : IUserRepository
    {
        private readonly OttContext _context;

        public SqlUserRepo(OttContext context)
        {
            _context = context;
        }
        public async Task<User> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return  await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}