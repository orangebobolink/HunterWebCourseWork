using DAL.Entities;

namespace BLL.DTOs.UserDTOs
{
    public class UserDetailDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string MessangerName { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = new List<string>();
    }
}
