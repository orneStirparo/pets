using FluentValidation;

namespace PetMatch.Application.Commands.Pets;

public class PetCommandValidator : AbstractValidator<PetCommand>
{
    public PetCommandValidator()
    {
        RuleFor(x => x.Name)
        .NotEmpty().WithMessage("Name must contain a value")
        .Must(x => x is string)
        .WithMessage("Name is not valid");
        RuleFor(x => x.Description)
        .NotEmpty().WithMessage("Description must contain a value");
        RuleFor(x => x.Url)
        .NotEmpty().WithMessage("Url must contain a value")
         .Must(BeAValidUrl)
            .WithMessage("Invalid URL.");;
    }
    private bool BeAValidUrl(string url)
    {
        Uri uriResult;
        return Uri.TryCreate(url, UriKind.Absolute, out uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
}