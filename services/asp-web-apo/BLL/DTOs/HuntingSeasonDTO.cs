namespace BLL.DTOs
{
    public class HuntingSeasonDTO
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Description { get; set; } = string.Empty;
        public int AnimalId { get; set; }
    }
}
