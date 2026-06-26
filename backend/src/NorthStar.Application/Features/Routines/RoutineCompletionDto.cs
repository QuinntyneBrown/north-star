namespace NorthStar.Application.Features.Routines;

public sealed record RoutineCompletionDto(Guid RoutineId, bool Completed, int StarsAwarded, int CurrentStreak);
