using DNDCatalog.Core.MagicItemAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNDCatalog.Infrastructure.Data.Config;
public class MagicItemConfiguration : IEntityTypeConfiguration<MagicItem>
{
    public void Configure(EntityTypeBuilder<MagicItem> builder)
    {
        builder.HasMany(mi => mi.Hashtags).WithMany(h => h.MagicItems);

        builder.OwnsOne(mi => mi.Price,
            (p) =>
            {
                p.Property(c => c.MinPrice).IsRequired(false);
                p.Property(c => c.MaxPrice).IsRequired(false);
                p.Property(c => c.Formula).HasMaxLength(50).IsUnicode().IsRequired(false);
                p.Property(c => c.Notes).HasMaxLength(200).IsUnicode().IsRequired(false);
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

        builder.Property(p => p.DescriptionUa)
            .IsUnicode()
            .IsRequired(false);

        builder.Property(p => p.DescriptionUa1)
            .IsUnicode()
            .IsRequired(false);

        builder.Property(p => p.DescriptionUa2)
            .IsUnicode()
            .IsRequired(false);

        builder.Property(p => p.DescriptionRus1)
            .IsUnicode()
            .IsRequired(false);

        builder.Property(p => p.DescriptionRus2)
            .IsUnicode()
            .IsRequired(false);

        builder.Property(p => p.Source)
            .HasMaxLength(100)
            .IsUnicode()
            .IsRequired(false);

        builder.Property(p => p.MagicBonus)
            .IsRequired(false);

    }
}
