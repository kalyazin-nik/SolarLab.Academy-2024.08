using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.DataAccess.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(5000).IsRequired();
        builder.Property(x => x.Number).HasMaxLength(100).IsRequired();

        builder.HasMany(x => x.Adverts).WithOne(x => x.Category).HasForeignKey(x => x.CategoryID).IsRequired().OnDelete(DeleteBehavior.Cascade);
    }
}
