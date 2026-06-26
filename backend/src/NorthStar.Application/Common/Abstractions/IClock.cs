namespace NorthStar.Application.Common.Abstractions;

/// <summary>Abstraction over the system clock for testability.</summary>
public interface IClock
{
    DateTimeOffset UtcNow { get; }
}
