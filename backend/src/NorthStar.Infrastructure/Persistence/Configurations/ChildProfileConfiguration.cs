using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthStar.Domain.Children;

namespace NorthStar.Infrastructure.Persistence.Configurations;

public sealed class ChildProfileConfiguration : IEntityTypeConfiguration<ChildProfile>
{
    public void Configure(EntityTypeBuilder<ChildProfile> builder)
    {
        builder.ToTable("ChildProfiles");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.FirstName).IsRequired().HasMaxLength(60);
        builder.Property(c => c.Interests).HasMaxLength(300);
        builder.Property(c => c.LoginHandle).IsRequired().HasMaxLength(40);
        builder.Property(c => c.PinHash).IsRequired();
        builder.HasIndex(c => c.LoginHandle).IsUnique();
        builder.HasIndex(c => c.FamilyId);
    }
}
