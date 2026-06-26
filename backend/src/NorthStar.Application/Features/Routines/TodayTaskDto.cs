namespace NorthStar.Application.Features.Routines;

public sealed record TodayTaskDto(Guid RoutineId, string Title, string Icon, int StarReward, bool Done);
