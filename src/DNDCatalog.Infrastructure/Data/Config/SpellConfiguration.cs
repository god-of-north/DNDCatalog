using DNDCatalog.Core.SpellAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNDCatalog.Infrastructure.Data.Config;
public class SpellConfiguration : IEntityTypeConfiguration<Spell>
{
    public void Configure(EntityTypeBuilder<Spell> builder)
    {
        builder.HasMany(s => s.Classes).WithMany(c => c.Spells);
        builder.HasMany(s => s.Archetypes).WithMany(a => a.Spells);
        builder.HasMany(s => s.Tags).WithMany(t => t.Spells);

        builder.OwnsOne(s => s.CastingTime,
            (ct) =>
            {
                ct.OwnsOne(c => c.ActionTime);
                ct.Property(c => c.Time)
                    .HasColumnType("varchar(15)")
                    .HasConversion(
                        v => v.Value.ToString(),
                        v => TimeSpan.Parse(v)); ;
            });

        builder.OwnsOne(s => s.Range);
        builder.OwnsOne(s => s.Duration,
            d =>
            {
                d.Property(x => x.Time)
                    .HasColumnType("varchar(15)")
                    .HasConversion(
                        v => v.Value.ToString(),
                        v => TimeSpan.Parse(v)); ;
            });

        builder.Property(p => p.NameUa)
            .HasMaxLength(150)
            .IsUnicode()
            .IsRequired(false);

        builder.Property(p => p.NameRus)
            .HasMaxLength(150)
            .IsUnicode()
            .IsRequired(false);

        builder.Property(p => p.NameEng)
            .HasMaxLength(150)
            .IsUnicode()
            .IsRequired(false);

        builder.Property(p => p.DescriptionEng)
            .IsUnicode()
            .IsRequired(false);

        builder.Property(p => p.DescriptionUa1)
            .IsUnicode()
            .IsRequired(false);

        builder.Property(p => p.DescriptionUa2)
            .IsUnicode()
            .IsRequired(false);

        builder.Property(p => p.DescriptionUa3)
            .IsUnicode()
            .IsRequired(false);

        builder.Property(p => p.DescriptionRu1)
            .IsUnicode()
            .IsRequired(false);

        builder.Property(p => p.DescriptionRu2)
            .IsUnicode()
            .IsRequired(false);

        builder.Property(p => p.ComponentMDescription)
            .HasMaxLength(250)
            .IsUnicode()
            .IsRequired(false);

        builder.Property(p => p.Source)
            .HasMaxLength(100)
            .IsUnicode()
            .IsRequired(false);

        builder.Property(p => p.ShortName)
            .HasMaxLength(100)
            .IsUnicode(false)
            .IsRequired();
        builder.HasIndex(p=>p.ShortName);

    }
}
