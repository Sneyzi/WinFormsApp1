using Microsoft.EntityFrameworkCore;

namespace WinFormsApp1
{
    // Пункт 1: Code First
    public class AppDbContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<PostOffice> PostOffices { get; set; }
        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PostOfficeDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Пункт 4: Один до одного
            modelBuilder.Entity<Parcel>()
                .HasOne(p => p.Client)
                .WithOne()
                .HasForeignKey<Parcel>(p => p.ClientId);

            // Пункт 5: Один до багатьох
            modelBuilder.Entity<PostOffice>()
                .HasMany(po => po.Parcels)
                .WithOne(p => p.PostOffice)
                .HasForeignKey(p => p.PostOfficeId);

            // Пункт 6: Багато до багатьох (City -> PostOffice через проміжну таблицю)
            modelBuilder.Entity<City>()
                .HasMany(c => c.PostOffices)
                .WithOne()
                .HasForeignKey("CityId");
        }
    }
}