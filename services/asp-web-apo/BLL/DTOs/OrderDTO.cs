using DAL.Entities.UserEntities;
using DAL.Entities;

namespace BLL.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public DateTime FilingDate { get; set; } = DateTime.Now;
        public string FirstName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string MessangerName { get; set; } = string.Empty;
        public User? User { get; set; }
        public int NumberHunters { get; set; }
        public int CountDates { get; set; }
        public bool IncludeHouse { get; set; } = false;
        public string AdditionalInfo { get; set; } = string.Empty;
    }
}
