using System.ComponentModel.DataAnnotations;

namespace DAL.Entities.UserEntities
{
    public class User
    {
        // TODO: дописать
        public int Id { get; set; }
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PasswordHash { get; set; } = string.Empty;
        public int UserDatailId { get; set; }
        public UserDetail? UserDetail { get; set; }
    }
}
