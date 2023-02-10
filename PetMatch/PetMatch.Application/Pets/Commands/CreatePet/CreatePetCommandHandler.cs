using PetMatch.Domain.Pets;
using ErrorOr;
using MediatR;
using PetMatch.Application.Common.Interfaces.Persistance;
using PetMatch.Domain.Pets.ValueObjects;

namespace PetMatch.Application.Pets.Commands.CreatePet;

public class CreatePetCommandHandler : IRequestHandler<CreatePetCommand, ErrorOr<Pet>>
{
    private readonly IPetRepository _petRepository;

    public CreatePetCommandHandler(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    public async Task<ErrorOr<Pet>> Handle(CreatePetCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var pet = Pet.Create(
            PetId: PetId.Create(request.PetId),
            name: request.Name,
            description: request.Description,
            url: request.Url
           );

        _petRepository.Add(pet);

        return pet;
    }
}