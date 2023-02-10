using PetMatch.Application.Common.Interfaces.Persistance;
using PetMatch.Domain.Pets;

namespace PetMatch.Infrastructure.Persistence.Repositories;

public sealed class PetRepository : IPetRepository
{
    private readonly PetMatchDbContext _dbContext;

    public PetRepository(PetMatchDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Pet pet)
    {
        _dbContext.Add(pet);
        _dbContext.SaveChanges();
    }
}