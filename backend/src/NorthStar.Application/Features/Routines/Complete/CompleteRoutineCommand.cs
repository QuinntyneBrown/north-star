using MediatR;

namespace NorthStar.Application.Features.Routines.Complete;

public sealed record CompleteRoutineCommand(Guid RoutineId) : IRequest<RoutineCompletionDto>;
