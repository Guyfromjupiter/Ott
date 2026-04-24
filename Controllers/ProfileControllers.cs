using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ott.Dto;
using Ott.Services;
using System.Security.Claims;

[ApiController]
[Route("api/profiles")]
[Authorize]


public class ProfileController : ControllerBase
{
    private readonly ProfileService _profileService;

    public ProfileController(ProfileService profileService)
    {
        _profileService = profileService;
    }

    private int GetUserId()
    {
        return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
    }

    [HttpGet]
    public async Task<IActionResult> GetProfiles()
    {
        var profiles = await _profileService.GetProfilesByUser(GetUserId());
        return Ok(profiles);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProfile(CreateProfilesDTO dto)
    {
        var profile = await _profileService.CreateProfile(GetUserId(), dto);
        return Ok(profile);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProfile(int id, CreateProfilesDTO dto)
    {
        await _profileService.UpdateProfile(id, GetUserId(), dto);
        return Ok("Updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProfile(int id)
    {
        await _profileService.DeleteProfile(id, GetUserId());
        return Ok("Deleted");
    }
}
