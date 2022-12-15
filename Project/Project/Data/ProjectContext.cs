using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data
{
    public class ProjectContext: DbContext 
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ContactInformation> ContactInformation { get; set; }
        public DbSet<Leased> Leased { get; set; }
        

        public ProjectContext(DbContextOptions<ProjectContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One to Many
            modelBuilder.Entity<Location>()
                .HasMany(l => l.Apartments)
                .WithOne(a => a.Location);

            // Many to Many
            // Cheia compusa
            modelBuilder.Entity<Leased>()
                .HasKey(l => new { l.UserId, l.ApartmentId });

            modelBuilder.Entity<Leased>()
                .HasOne<User>(l => l.User)
                .WithMany(u => u.Leased)
                .HasForeignKey(l => l.UserId);

            modelBuilder.Entity<Leased>()
                .HasOne<Apartment>(l => l.Apartment)
                .WithMany(a => a.Leased)
                .HasForeignKey(l => l.ApartmentId);

            // One to One
            modelBuilder.Entity<User>()
                .HasOne(u => u.ContactInformation)
                .WithOne(ci => ci.User)
                .HasForeignKey<ContactInformation>(ci => ci.UserId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
