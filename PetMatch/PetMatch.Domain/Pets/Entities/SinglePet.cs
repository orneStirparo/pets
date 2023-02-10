using PetMatch.Domain.Common.Models;
using PetMatch.Domain.Pets.ValueObjects;

namespace PetMatch.Domain.Pets.Entites;

public sealed class SinglePet : Entity<PetId>
{
    public string Name { get; }
    public string Description { get; }
    public string Url { get; }
    private SinglePet(PetId petId, string name, string description, string url)
        : base(petId)
    {
        Name = name;
        Description = description;
        Url = url;
    }

    public static SinglePet Create(string name, string description, string url)
    {
        return new(PetId.CreateUnique(), name, description, url);
    }

#pragma warning disable CS8618
    private SinglePet() { }
#pragma warning restore CS8618
}