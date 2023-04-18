using DAL.Entities.UserEntities;

namespace DAL.Entities
{
    public class Messanger
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<UserDetail> UserDetails { get; set; } = new();
        public List<Order> Orders { get; set; } = new();
    }
}
