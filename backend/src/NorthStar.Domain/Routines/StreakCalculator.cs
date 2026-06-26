namespace NorthStar.Domain.Routines;

/// <summary>Computes the current daily streak from the set of days that had a completion.</summary>
public static class StreakCalculator
{
    public static int Current(IReadOnlySet<DateOnly> completedDates, DateOnly today)
    {
        // Count today if done; otherwise start from yesterday so an in-progress day doesn't reset it.
        var day = completedDates.Contains(today) ? today : today.AddDays(-1);

        var streak = 0;
        while (completedDates.Contains(day))
        {
            streak++;
            day = day.AddDays(-1);
        }

        return streak;
    }
}
