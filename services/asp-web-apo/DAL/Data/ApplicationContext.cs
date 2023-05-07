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
        public DbSet<Role> Roles { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Status> Statuses { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(user => user.Email)
                .IsUnique();

            modelBuilder.Entity<Token>()
                .HasIndex(token => token.RefreshToken)
                .IsUnique();

            modelBuilder.Entity<UserDetail>()
               .HasIndex(user => user.Phone)
               .IsUnique();

            modelBuilder.Entity<Animal>()
               .HasIndex(animal => animal.Name)
               .IsUnique();

            modelBuilder.Entity<Messanger>()
              .HasIndex(messanger => messanger.Name)
              .IsUnique();

            modelBuilder.Entity<Role>()
              .HasIndex(role => role.Name)
              .IsUnique();

            modelBuilder.Entity<RoleUser>()
                .HasKey(x => new { x.RoleId, x.UserId });

            modelBuilder.Entity<Role>()
                .HasMany(c => c.Users)
                .WithMany(s => s.Roles)
                .UsingEntity<RoleUser>(
                j => j.HasOne(pt => pt.User)
                    .WithMany(p => p.RoleUsers)
                    .HasForeignKey(pt => pt.UserId),
                j => j.HasOne(pt => pt.Role)
                    .WithMany(t => t.RoleUsers)
                    .HasForeignKey(pt => pt.RoleId));
        }
    }
}
