using FluentValidation;

namespace NorthStar.Application.Features.Children.Create;

public sealed class CreateChildCommandValidator : AbstractValidator<CreateChildCommand>
{
    public CreateChildCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(60);
        RuleFor(x => x.Grade).InclusiveBetween(1, 12);
        RuleFor(x => x.LoginHandle)
            .NotEmpty().MinimumLength(3).MaximumLength(40)
            .Matches("^[a-zA-Z0-9_.-]+$")
            .WithMessage("Login handle may use letters, numbers, dots, dashes and underscores.");
        RuleFor(x => x.Pin).NotEmpty().Matches(@"^\d{4,6}$").WithMessage("PIN must be 4 to 6 digits.");
        RuleFor(x => x.Interests).MaximumLength(300);
        RuleFor(x => x.BirthYear).InclusiveBetween(2000, 2025).When(x => x.BirthYear.HasValue);
    }
}
