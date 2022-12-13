using DNDCatalog.Core.HashtagAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNDCatalog.Infrastructure.Data.Config;
public class HashtagConfiguration : IEntityTypeConfiguration<Hashtag>
{
    public void Configure(EntityTypeBuilder<Hashtag> builder)
    {
        builder.HasMany(h => h.MagicItems).WithMany(mi => mi.Hashtags);

        builder.Property(p => p.Name)
            .HasMaxLength(50)
            .IsUnicode()
            .IsRequired();

    }
}
