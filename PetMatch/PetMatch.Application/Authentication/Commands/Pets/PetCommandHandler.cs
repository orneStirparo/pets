using PetMatch.Domain.Pets;
using ErrorOr;
using MediatR;
using PetMatch.Application.Common.Interfaces.Persistance;
using PetMatch.Domain.Pets.ValueObjects;

namespace PetMatch.Application.Commands.Pets;

public class CreatePetCommandHandler : IRequestHandler<PetCommand, ErrorOr<Pet>>
{
    private readonly IPetRepository _petRepository;

    public CreatePetCommandHandler(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    public async Task<ErrorOr<Pet>> Handle(PetCommand request, CancellationToken cancellationToken)
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