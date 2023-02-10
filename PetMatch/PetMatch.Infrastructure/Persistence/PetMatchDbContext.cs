using Microsoft.EntityFrameworkCore;
using PetMatch.Domain.Pets;

namespace PetMatch.Infrastructure.Persistence;

public sealed class PetMatchDbContext : DbContext
{
    public PetMatchDbContext(DbContextOptions<PetMatchDbContext> options)
        : base(options) { }

    public DbSet<Pet> Pet { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(PetMatchDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}