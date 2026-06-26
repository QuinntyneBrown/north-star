namespace NorthStar.Infrastructure.Identity;

public sealed class JwtOptions
{
    public const string SectionName = "Jwt";

    public string Issuer { get; set; } = "north-star";
    public string Audience { get; set; } = "north-star-app";
    public string SigningKey { get; set; } = string.Empty;
    public int ExpiryMinutes { get; set; } = 120;
}
