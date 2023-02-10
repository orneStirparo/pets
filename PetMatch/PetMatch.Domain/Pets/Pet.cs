using PetMatch.Domain.Common.Models;
using PetMatch.Domain.Pets.ValueObjects;

namespace PetMatch.Domain.Pets;

public sealed class Pet : AggregateRoot<PetId>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Url { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Pet(
        PetId petId,
        string name,
        string description, 
        string url)
        : base(petId)
    {
        Name = name;
        Description = description;
        Url= url;
    }

    public static Pet Create(
        string name,
        string description,
        string url,
        PetId PetId)
    {
        return new(
            PetId.CreateUnique(),
            name,
            description, url);
    }

#pragma warning disable CS8618
    public Pet() { }
#pragma warning restore CS8618
}