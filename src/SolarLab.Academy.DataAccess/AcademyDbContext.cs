using Microsoft.EntityFrameworkCore;
using SolarLab.Academy.DataAccess.Configurations;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.DataAccess;

public class AcademyDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Advert> Adverts { get; set; } = null!;
    public DbSet<FileContent> Files { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new AdvertConfiguration());
        modelBuilder.ApplyConfiguration(new FileContentConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}
