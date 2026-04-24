using Ott.Data;
using Ott.Dto;
using Ott.Models;

namespace Ott.Services
{
public class ProfileService
{
    private readonly IProfileRepo _profileRepo;

    public ProfileService(IProfileRepo profileRepo)
    {
        _profileRepo = profileRepo;
    }

    public async Task<Profile> CreateProfile(int userId, CreateProfilesDTO dto)
    {
        var profile = new Profile
        {
            UserId = userId,
            Name = dto.Name
        };

        return await _profileRepo.AddAsync(profile);
    }

    public async Task<List<Profile>> GetProfilesByUser(int userId)
    {
        return await _profileRepo.GetByUserIdAsync(userId);
    }

    public async Task DeleteProfile(int profileId, int userId)
    {
        var profile = await _profileRepo.GetByIdAsync(profileId);

        if (profile == null || profile.UserId != userId)
            throw new Exception("Unauthorized");

        await _profileRepo.DeleteAsync(profileId);
    }

    public async Task UpdateProfile(int profileId, int userId, CreateProfilesDTO dto)
    {
        var profile = await _profileRepo.GetByIdAsync(profileId);

        if (profile == null || profile.UserId != userId)
            throw new Exception("Unauthorized");

        profile.Name = dto.Name;

        await _profileRepo.UpdateAsync(profile);
    }
}
}