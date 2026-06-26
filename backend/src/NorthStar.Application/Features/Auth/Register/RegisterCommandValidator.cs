using FluentValidation;

namespace NorthStar.Application.Features.Auth.Register;

public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
        RuleFor(x => x.DisplayName).NotEmpty().MaximumLength(80);
        RuleFor(x => x.FamilyName).NotEmpty().MaximumLength(80);
    }
}
