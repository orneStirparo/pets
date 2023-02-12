using PetMatch.Application.Commands.Pets;
using PetMatch.Contracts.Pets;
using PetMatch.Domain.Pets;
using Mapster;
using SinglePet = PetMatch.Domain.Pets.Entites.SinglePet;

namespace PetMatch.Api.Common.Mapping;

public class PetMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreatePetRequest Request, Guid PetId), PetCommand>()
            .Map(dest => dest.PetId, src => src.PetId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<(UpdatePetRequest Request, Guid PetId), PetCommand>()
            .Map(dest => dest.PetId, src => src.PetId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<Pet, PetResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<SinglePet, SinglePetResponse>()
            .Map(dest => dest.Id, src => src.Id);
    }
}