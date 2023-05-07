using DAL.Entities.UserEntities;

namespace BLL.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string UserEmail { get; set; } = string.Empty;
        public DateTime FilingDate { get; set; } = DateTime.Now;
        public int NumberHunters { get; set; }
        public int CountDates { get; set; }
        public bool IncludeHouse { get; set; }
        public string AdditionalInfo { get; set; } = string.Empty;
        public string StatusName { get; set; } = string.Empty;
    }
}
