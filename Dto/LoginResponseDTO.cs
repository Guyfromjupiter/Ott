namespace Ott.Dto
{
    public class LoginResposeDTO   
    {
        public String? Token { get; set; }
        public int UserId { get; set; }
        public IEnumerable<ProfileResponseDTO>? profile {get; set;}
    }
}