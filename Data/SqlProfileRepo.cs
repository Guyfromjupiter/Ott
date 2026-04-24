using Microsoft.EntityFrameworkCore;
using Ott.Models;

namespace Ott.Data
{
    public class SqlProfileRepo : IProfileRepo
{
    private readonly OttContext _context;

    public SqlProfileRepo(OttContext context)
    {
        _context = context;
    }

    public async Task<Profile> AddAsync(Profile profile)
    {
        await _context.Profiles.AddAsync(profile);
        await _context.SaveChangesAsync();
        return profile;
    }

    public async Task<List<Profile>> GetByUserIdAsync(int userId)
    {
        return await _context.Profiles
            .Where(p => p.UserId == userId)
            .ToListAsync();
    }

    public async Task<Profile?> GetByIdAsync(int profileId)
    {
        return await _context.Profiles
            .FirstOrDefaultAsync(p => p.ProfileId == profileId);
    }

    public async Task UpdateAsync(Profile profile)
    {
        _context.Profiles.Update(profile);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int profileId)
    {
        var profile = await _context.Profiles.FindAsync(profileId);

        if (profile != null)
        {
            _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();
        }
    }
}
}