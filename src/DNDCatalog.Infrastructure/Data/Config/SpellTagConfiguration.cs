using DNDCatalog.Core.SpellAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNDCatalog.Infrastructure.Data.Config;
public class SpellTagConfiguration : IEntityTypeConfiguration<SpellTag>
{
  public void Configure(EntityTypeBuilder<SpellTag> builder)
  {
    builder.HasMany(t => t.Spells).WithMany(s => s.Tags);

    builder.Property(p => p.Name)
        .HasMaxLength(50)
        .IsUnicode();

  }
}
