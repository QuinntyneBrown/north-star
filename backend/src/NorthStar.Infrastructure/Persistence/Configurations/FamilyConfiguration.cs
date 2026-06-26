using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthStar.Domain.Families;

namespace NorthStar.Infrastructure.Persistence.Configurations;

public sealed class FamilyConfiguration : IEntityTypeConfiguration<Family>
{
    public void Configure(EntityTypeBuilder<Family> builder)
    {
        builder.ToTable("Families");
        builder.HasKey(f => f.Id);
        builder.Property(f => f.Name).IsRequired().HasMaxLength(80);
        builder.Property(f => f.CreatedAtUtc).IsRequired();
    }
}
