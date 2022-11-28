using DNDCatalog.Core.ClassAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNDCatalog.Infrastructure.Data.Config;
public class ClassConfiguration : IEntityTypeConfiguration<Class>
{
    public void Configure(EntityTypeBuilder<Class> builder)
    {
        builder.HasMany(c => c.Archetypes).WithOne(a => a.Class);
        builder.HasMany(c => c.Spells).WithMany(s => s.Classes);

        builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Description)
            .IsRequired(false);
    }
}
