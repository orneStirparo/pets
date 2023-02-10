using PetMatch.Domain.Pets;

namespace PetMatch.Application.Common.Interfaces.Persistance;

public interface IPetRepository
{
    void Add(Pet pet);
}