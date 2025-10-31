using SkodaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace SkodaApi.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options) { }

  public DbSet<Banner> Banners => Set<Banner>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // EF Core не зберігає List<string> напряму, тому збережемо як JSON
    modelBuilder.Entity<Banner>()
        .Property(b => b.ListItems)
        .HasConversion(
            v => string.Join(";", v),
            v => v.Split(";", StringSplitOptions.RemoveEmptyEntries).ToList()
        );
  }
}