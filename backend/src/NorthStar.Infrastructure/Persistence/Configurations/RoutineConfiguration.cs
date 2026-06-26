using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthStar.Domain.Routines;

namespace NorthStar.Infrastructure.Persistence.Configurations;

public sealed class RoutineConfiguration : IEntityTypeConfiguration<Routine>
{
    public void Configure(EntityTypeBuilder<Routine> builder)
    {
        builder.ToTable("Routines");
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Title).IsRequired().HasMaxLength(80);
        builder.Property(r => r.Icon).HasMaxLength(8);
        builder.Property(r => r.Cadence).HasConversion<string>().HasMaxLength(16);
        builder.HasIndex(r => r.ChildProfileId);
    }
}
