namespace BLL.DTOs.HuntingSeason
{
    public class HuntingSeasonDetailDTO
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Description { get; set; } = string.Empty;
        public string TypeName { get; set; } = string.Empty;
        public string MethodName { get; set; } = string.Empty;
        public string HuntingTime { get; set; } = string.Empty;
        public string GenderName { get; set; } = string.Empty;
        public string Age { get; set; } = string.Empty;
    }
}
