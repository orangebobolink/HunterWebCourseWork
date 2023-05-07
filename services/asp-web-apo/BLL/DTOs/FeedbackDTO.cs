namespace BLL.DTOs
{
    public class FeedbackDTO
    {
        public int Id { get; set; }
        public string UserEmail { get; set; } = string.Empty;
        public string UserFirstName { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int Mark { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
