using Microsoft.EntityFrameworkCore;
using SimSetup.Shared.Models;

namespace SimSetup.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Car> Cars => Set<Car>();
    public DbSet<Track> Tracks => Set<Track>();
    public DbSet<Setup> Setups => Set<Setup>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Relacja 1-do-wielu: Car -> Setups
        modelBuilder.Entity<Setup>()
            .HasOne(s => s.Car)
            .WithMany(c => c.Setups)
            .HasForeignKey(s => s.CarId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relacja 1-do-wielu: Track -> Setups
        modelBuilder.Entity<Setup>()
            .HasOne(s => s.Track)
            .WithMany(t => t.Setups)
            .HasForeignKey(s => s.TrackId)
            .OnDelete(DeleteBehavior.Cascade);

        // Opcjonalne dane początkowe (Seed Data) ułatwiające weryfikację sprintu 1
        modelBuilder.Entity<Car>().HasData(
            new Car { Id = 1, Brand = "Ferrari", Model = "488 GT3 Evo", Year = 2020 },
            new Car { Id = 2, Brand = "Porsche", Model = "911 GT3 R (992)", Year = 2023 },
            new Car { Id = 3, Brand = "BMW", Model = "M4 GT3", Year = 2022 }
        );

        modelBuilder.Entity<Track>().HasData(
            new Track { Id = 1, Name = "Circuit de Spa-Francorchamps", Country = "Belgium", LengthKm = 7.004 },
            new Track { Id = 2, Name = "Autodromo Nazionale Monza", Country = "Italy", LengthKm = 5.793 },
            new Track { Id = 3, Name = "Nürburgring GP", Country = "Germany", LengthKm = 5.148 }
        );

        modelBuilder.Entity<Setup>().HasData(
            new Setup
            {
                Id = 1,
                CarId = 1,
                TrackId = 1,
                LapTime = TimeSpan.Parse("00:02:18.450"),
                TirePressureFront = 27.5,
                TirePressureRear = 27.2,
                AeroFront = 4,
                AeroRear = 8,
                Notes = "Bazowy setup na suchy tor Spa. Stabilny tył w Eau Rouge.",
                CreatedAt = new DateTime(2026, 9, 20, 12, 0, 0, DateTimeKind.Utc)
            }
        );
    }
}
