namespace NorthStar.Domain.Identity;

/// <summary>Canonical role names used across the app for authorization.</summary>
public static class Roles
{
    public const string Owner = "Owner";
    public const string Child = "Child";
    public const string Mentor = "Mentor";

    public static readonly IReadOnlyList<string> All = new[] { Owner, Child, Mentor };
}
