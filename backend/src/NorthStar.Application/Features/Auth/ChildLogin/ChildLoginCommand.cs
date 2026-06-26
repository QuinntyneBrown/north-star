using MediatR;

namespace NorthStar.Application.Features.Auth.ChildLogin;

public sealed record ChildLoginCommand(string LoginHandle, string Pin) : IRequest<AuthResponse?>;
