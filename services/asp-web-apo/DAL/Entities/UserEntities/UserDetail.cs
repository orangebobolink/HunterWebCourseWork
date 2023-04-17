namespace DAL.Entities.UserEntities
{
    public class UserDetail
    {
        public int Id { get; set; }
        public int? MessangerId { get; set; }
        public Messanger? Messanger { get; set; }

    }
}
