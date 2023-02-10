using PetMatch.Domain.Pets;
using PetMatch.Domain.Pets.Entites;
using PetMatch.Domain.Pets.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PetMatch.Infrastructure.Persistence.Configurations;

internal sealed class PetConfigurations : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        ConfigurePetsTable(builder);
    }

    private void ConfigurePetsTable(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("Pets");

        builder.HasKey(m => m.Id);

        builder
            .Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => PetId.Create(value));

        builder
            .Property(m => m.Name)
            .HasMaxLength(100);

        builder
            .Property(m => m.Description)
            .HasMaxLength(100);

        builder
            .Property(m => m.Url)
            .HasMaxLength(100);

    }

}