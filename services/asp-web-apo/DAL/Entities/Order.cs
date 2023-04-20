using DAL.Entities.UserEntities;

namespace DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime FilingDate { get; set; } = DateTime.Now;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int? MessangerId { get; set; }
        public Messanger? Messanger { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int NumberHunters { get; set; }
        public int CountDates { get; set; }
        public bool IncludeHouse { get; set; } = false;
        public string AdditionalInfo { get; set; } = string.Empty;
    }
}
