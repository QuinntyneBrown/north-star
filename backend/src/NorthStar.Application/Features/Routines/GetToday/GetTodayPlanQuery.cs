using MediatR;

namespace NorthStar.Application.Features.Routines.GetToday;

public sealed record GetTodayPlanQuery(Guid ChildId) : IRequest<TodayPlanDto>;
