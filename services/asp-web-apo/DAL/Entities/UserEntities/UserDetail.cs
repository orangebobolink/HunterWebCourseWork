namespace DAL.Entities.UserEntities
{
    public class UserDetail
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int? MessangerId { get; set; }
        public Messanger? Messanger { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
