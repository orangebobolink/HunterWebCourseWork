using DAL.Entities;

namespace BLL.DTOs.UserDTOs
{
    public class RegisterUserDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Messanger { get; set; } = string.Empty;
    }
}
