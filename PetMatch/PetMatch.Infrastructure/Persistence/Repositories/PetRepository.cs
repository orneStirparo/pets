using PetMatch.Application.Common.Interfaces.Persistance;
using PetMatch.Domain.Pets;
using PetMatch.Domain.Pets.ValueObjects;

namespace PetMatch.Infrastructure.Persistence.Repositories;

public sealed class PetRepository : IPetRepository
{
    private readonly PetMatchDbContext _dbContext;

    public PetRepository(PetMatchDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IEnumerable<Pet> GetAll()
    {
        return _dbContext.Pet;
    }

    public void Add(Pet pet)
    {
        _dbContext.Add(pet);
        _dbContext.SaveChanges();
    }

     public Pet GetById(Guid id)
    {
        return getPet(id);
    }

    public void Update(Pet reqPet)
    {
        _dbContext.Update(reqPet);
        _dbContext.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var pet = getPet(id);
        _dbContext.Remove(pet);
        _dbContext.SaveChanges();
    }
     private Pet getPet(Guid id)
    {
        Pet finalPet = new Pet();
        foreach (var pet in _dbContext.Pet)
        {
            if(pet.Id.Value.Equals(id)){
                finalPet = pet;
            }
        }
        if (finalPet == null) throw new KeyNotFoundException("Pet not found");
        return finalPet;
    }
}