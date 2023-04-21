namespace BLL.DTOs
{
    public class TokenDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
    }
}
