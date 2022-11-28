using DNDCatalog.Core.ClassAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNDCatalog.Infrastructure.Data.Config;
public class ArchetypeConfiguration : IEntityTypeConfiguration<Archetype>
{
    public void Configure(EntityTypeBuilder<Archetype> builder)
    {
        builder.HasOne(a => a.Class).WithMany(c => c.Archetypes);
        builder.HasMany(a => a.Spells).WithMany(s => s.Archetypes);

        builder.Property(p => p.Name)
            .HasMaxLength(150)
            .IsRequired();

    }
}
