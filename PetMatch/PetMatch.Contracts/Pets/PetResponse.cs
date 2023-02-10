namespace PetMatch.Contracts.Pets;

public record PetResponse(
    string Id,
    string Name,
    string Description,
    string Url,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime);

public record SinglePetResponse(
    string Id,
    string Name,
    string Url,
    string Description);