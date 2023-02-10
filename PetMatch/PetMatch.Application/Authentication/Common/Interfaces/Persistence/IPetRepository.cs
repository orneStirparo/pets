using PetMatch.Domain.Pets;

namespace PetMatch.Application.Common.Interfaces.Persistance;

public interface IPetRepository
{
    void Add(Pet pet);
    IEnumerable<Pet> GetAll();
    Pet GetById(Guid id);
    void Update(Pet pet);
}