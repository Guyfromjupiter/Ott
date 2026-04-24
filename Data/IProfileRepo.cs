using Ott.Models;

public interface IProfileRepo
{
    Task<Profile> AddAsync(Profile profile);

    Task<List<Profile>> GetByUserIdAsync(int userId);

    Task<Profile?> GetByIdAsync(int profileId);

    Task UpdateAsync(Profile profile);        

    Task DeleteAsync(int profileId);        
}