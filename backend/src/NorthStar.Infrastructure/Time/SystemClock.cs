using NorthStar.Application.Common.Abstractions;

namespace NorthStar.Infrastructure.Time;

public sealed class SystemClock : IClock
{
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}
