namespace PetMatch.Contracts.Pets;

public record UpdatePetRequest(
    string Name,
    string Description,
    string Url);

