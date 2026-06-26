using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NorthStar.Domain.Children;
using NorthStar.Domain.Families;
using NorthStar.Domain.Routines;
using NorthStar.Infrastructure.Identity;

namespace NorthStar.Infrastructure.Persistence;

public sealed class NorthStarDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public NorthStarDbContext(DbContextOptions<NorthStarDbContext> options) : base(options) { }

    public DbSet<Family> Families => Set<Family>();
    public DbSet<ChildProfile> Children => Set<ChildProfile>();
    public DbSet<Routine> Routines => Set<Routine>();
    public DbSet<RoutineLog> RoutineLogs => Set<RoutineLog>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(NorthStarDbContext).Assembly);
    }
}
