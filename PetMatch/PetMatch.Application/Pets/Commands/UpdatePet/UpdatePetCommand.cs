using PetMatch.Domain.Pets;
using ErrorOr;
using MediatR;

namespace PetMatch.Application.Pets.Commands.UpdatePet;

public record UpdatePetCommand(
    Guid PetId,
    string Name,
    string Description,
    string Url 
    ): IRequest<ErrorOr<Pet>>;

public record PetSectionCommand(
    string Name,
    string Description,
    string Url);

public record PetCommand(
    string Name,
    string Description,
    string Url);