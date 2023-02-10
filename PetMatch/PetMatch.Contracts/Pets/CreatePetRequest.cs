namespace PetMatch.Contracts.Pets;

public record CreatePetRequest(
    string Name,
    string Description,
    string Url);

public record SinglePet(
    Guid Id,
    string Name,
    string Description,
    string Url);
