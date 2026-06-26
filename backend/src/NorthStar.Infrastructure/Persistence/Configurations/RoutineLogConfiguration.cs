using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthStar.Domain.Routines;

namespace NorthStar.Infrastructure.Persistence.Configurations;

public sealed class RoutineLogConfiguration : IEntityTypeConfiguration<RoutineLog>
{
    public void Configure(EntityTypeBuilder<RoutineLog> builder)
    {
        builder.ToTable("RoutineLogs");
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Date).IsRequired();
        builder.HasIndex(l => new { l.RoutineId, l.Date }).IsUnique();
        builder.HasIndex(l => new { l.ChildProfileId, l.Date });
    }
}
