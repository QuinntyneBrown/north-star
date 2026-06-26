using MediatR;

namespace NorthStar.Application.Features.Auth.Register;

public sealed record RegisterCommand(
    string Email,
    string Password,
    string DisplayName,
    string FamilyName) : IRequest<AuthResponse>;
