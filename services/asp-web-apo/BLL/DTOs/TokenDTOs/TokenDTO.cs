namespace BLL.DTOs.TokenDTOs
{
    public class TokenDTO
    {
        public int UserId { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
    }
}
