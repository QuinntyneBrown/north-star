namespace NorthStar.Application.Features.Routines;

public sealed record TodayPlanDto(
    Guid ChildId,
    DateOnly Date,
    int Streak,
    int StarsToday,
    int CompletionPercent,
    IReadOnlyList<TodayTaskDto> Tasks);
