namespace BLL.DTOs.UserDTOs
{
    public class ResponseUserDto
    {
        public string Email { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = new List<string>();
        public string AccessToken { get; set; } = string.Empty;
    }
}
