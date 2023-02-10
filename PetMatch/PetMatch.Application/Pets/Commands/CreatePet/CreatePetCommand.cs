using PetMatch.Domain.Pets;
using ErrorOr;
using MediatR;

namespace PetMatch.Application.Pets.Commands.CreatePet;

public record CreatePetCommand(
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