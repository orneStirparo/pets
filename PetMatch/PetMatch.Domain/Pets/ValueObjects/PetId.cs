using PetMatch.Domain.Common.Models;

namespace PetMatch.Domain.Pets.ValueObjects;

public sealed class PetId : ValueObject
{
    public Guid Value { get; }

    private PetId(Guid value)
    {
        Value = value;
    }

    public static PetId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static PetId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private PetId() { }
}