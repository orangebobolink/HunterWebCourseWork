using DAL.Entities;
using DAL.Entities.AnimalEntities;
using DAL.Entities.HuntingSeasonEntities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<HuntingSeason> HuntingSeasons { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Messanger> Messangers { get; set; }
    }
}
