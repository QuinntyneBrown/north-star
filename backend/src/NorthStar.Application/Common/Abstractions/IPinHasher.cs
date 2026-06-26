namespace NorthStar.Application.Common.Abstractions;

/// <summary>Hashes and verifies a child's login PIN.</summary>
public interface IPinHasher
{
    string Hash(string pin);
    bool Verify(string hash, string pin);
}
