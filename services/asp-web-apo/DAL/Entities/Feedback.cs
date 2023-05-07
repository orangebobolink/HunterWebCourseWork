using DAL.Entities.UserEntities;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Feedback
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        [Required]
        [MaxLength(300)]
        public string Content { get; set; } = string.Empty;
        [MinLength(1), MaxLength(5), Required]
        public int Mark { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
