using Microsoft.AspNetCore.Identity;

namespace NorthStar.Infrastructure.Identity;

/// <summary>Identity user with the family it belongs to and a friendly display name.</summary>
public sealed class ApplicationUser : IdentityUser<Guid>
{
    public string DisplayName { get; set; } = string.Empty;
    public Guid FamilyId { get; set; }
}
