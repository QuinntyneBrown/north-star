using MediatR;
using NorthStar.Application.Common.Abstractions;

namespace NorthStar.Application.Features.Auth.Register;

public sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthResponse>
{
    private readonly IIdentityService _identityService;

    public RegisterCommandHandler(IIdentityService identityService) => _identityService = identityService;

    public Task<AuthResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        => _identityService.RegisterParentAsync(
            request.Email, request.Password, request.DisplayName, request.FamilyName, cancellationToken);
}
