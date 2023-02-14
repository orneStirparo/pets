using FluentValidation;

namespace PetMatch.Application.Authentication.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Email)
        .NotEmpty().WithMessage("Email must contain a value")
        .EmailAddress().WithMessage("Invalid email");
        RuleFor(x => x.Password)
        .NotEmpty().WithMessage("Password must contain a value")
        .MinimumLength(8).WithMessage("Password must contain at least 8 characters");
    }
}