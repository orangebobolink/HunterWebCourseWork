using DAL.Entities;
using DAL.Entities.AnimalEntities;
using DAL.Entities.HuntingSeasonEntities;
using DAL.Entities.UserEntities;
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
        public DbSet<Gender> Genders { get; set; }
        public DbSet<MethodOfHunting> Methods { get; set; }
        public DbSet<TypeOfHunting> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(user => user.Email)
                .IsUnique();

            modelBuilder.Entity<UserDetail>()
               .HasIndex(user => user.Phone)
               .IsUnique();

            modelBuilder.Entity<Animal>()
               .HasIndex(animal => animal.Name)
               .IsUnique();

            modelBuilder.Entity<Gender>()
               .HasIndex(gender => gender.Name)
               .IsUnique();

            modelBuilder.Entity<MethodOfHunting>()
              .HasIndex(method => method.Name)
              .IsUnique();

            modelBuilder.Entity<TypeOfHunting>()
              .HasIndex(type => type.Name)
              .IsUnique();

            modelBuilder.Entity<Messanger>()
              .HasIndex(messanger => messanger.Name)
              .IsUnique();
        }
    }
}
