namespace BLL.DTOs.TokenDTOs
{
    public class RefreshTokenDTO
    {
        public int UserId { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Expires { get; set; }
    }
}
