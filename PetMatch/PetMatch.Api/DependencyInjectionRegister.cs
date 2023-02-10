using PetMatch.Api.Common.Errors;
using PetMatch.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace PetMatch.Api;

public static class DependencyInjectionRegister
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, PetMatchProblemDetailsFactory>();
        services.AddMappings();
        return services;
    }
}