using Microsoft.EntityFrameworkCore;
using SkodaApi.Models;

namespace SkodaApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Banner> Banners => Set<Banner>();
    public DbSet<StockCar> StockCars => Set<StockCar>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Banner>()
            .Property(b => b.ListItems)
            .HasConversion(
                v => string.Join(";", v),
                v => v.Split(";", StringSplitOptions.RemoveEmptyEntries).ToList()
            );

        modelBuilder
            .Entity<StockCar>()
            .Property(s => s.Gallery)
            .HasConversion(
                v => string.Join(";", v),
                v => v.Split(";", StringSplitOptions.RemoveEmptyEntries).ToList()
            );

        modelBuilder.Entity<StockCar>().Property(s => s.Price).HasPrecision(18, 2);

        modelBuilder.Entity<StockCar>().Property(s => s.EngineVolume).HasPrecision(10, 2);

        modelBuilder.Entity<StockCar>().Property(s => s.FuelConsumption).HasPrecision(10, 2);

        modelBuilder.Entity<StockCar>().HasIndex(s => s.Vin).IsUnique();

        modelBuilder.Entity<StockCar>().HasIndex(s => s.Name);
    }
}
