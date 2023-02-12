using PetMatch.Domain.Pets;
using ErrorOr;
using MediatR;

namespace PetMatch.Application.Commands.Pets;

public record PetCommand(
    Guid PetId,
    string Name,
    string Description,
    string Url 
    ): IRequest<ErrorOr<Pet>>;

public record PetSectionCommand(
    string Name,
    string Description,
    string Url);
