using PetMatch.Application.Authentication.Common;
using PetMatch.Contracts.Authentication;
using Mapster;

namespace PetMatch.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}