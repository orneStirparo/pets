using FluentValidation;

namespace PetMatch.Application.Authentication.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FirstName)
        .NotEmpty().WithMessage("First name must contain a value");
        RuleFor(x => x.LastName)
        .NotEmpty().WithMessage("Last name must contain a value");
        RuleFor(x => x.Email)
        .NotEmpty().WithMessage("Email must contain a value")
        .EmailAddress().WithMessage("Invalid email");
        RuleFor(x => x.Password)
        .NotEmpty().WithMessage("Password must contain a value")
        .MinimumLength(8).WithMessage("Password must contain at least 8 characters");
        RuleFor(x => x.ConfirmPassword)
        .NotEmpty().WithMessage("Confirm Password must contain a value")
        .Equal(x => x.Password).WithMessage("Passwords do not match");
    }
}