using Microsoft.AspNetCore.Identity;
using NorthStar.Application.Common.Abstractions;

namespace NorthStar.Infrastructure.Identity;

/// <summary>Hashes child PINs using ASP.NET Identity's PBKDF2 password hasher.</summary>
public sealed class PinHasher : IPinHasher
{
    private static readonly object Subject = new();
    private readonly PasswordHasher<object> _hasher = new();

    public string Hash(string pin) => _hasher.HashPassword(Subject, pin);

    public bool Verify(string hash, string pin) =>
        _hasher.VerifyHashedPassword(Subject, hash, pin) != PasswordVerificationResult.Failed;
}
