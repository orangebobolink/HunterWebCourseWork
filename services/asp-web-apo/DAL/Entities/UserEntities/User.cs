using System.ComponentModel.DataAnnotations;

namespace DAL.Entities.UserEntities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<Role> Roles { get; set; } = new();
        public List<RoleUser> RoleUsers { get; set; } = new();
        public UserDetail? UserDetail { get; set; }
        public Token Token { get; set; }
    }
}
