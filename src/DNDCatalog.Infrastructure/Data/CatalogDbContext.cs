using System.Reflection;
using DNDCatalog.Core.ClassAggregate;
using DNDCatalog.Core.HashtagAggregate;
using DNDCatalog.Core.MagicItemAggregate;
using DNDCatalog.Core.SpellAggregate;
using DNDCatalog.SharedKernel;
using DNDCatalog.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DNDCatalog.Infrastructure.Data;


public class CatalogDbContext : DbContext
{
    private readonly IDomainEventDispatcher? _dispatcher;

    public CatalogDbContext(DbContextOptions<CatalogDbContext> options,
      IDomainEventDispatcher? dispatcher)
        : base(options)
    {
        _dispatcher = dispatcher;
    }

    public DbSet<Spell> Spells => Set<Spell>();
    public DbSet<SpellTag> SpellTags => Set<SpellTag>();
    public DbSet<Class> Classes => Set<Class>();
    public DbSet<Archetype> Archetypes => Set<Archetype>();
    public DbSet<MagicItem> MagicItems => Set<MagicItem>();
    public DbSet<Hashtag> Hashtags => Set<Hashtag>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        // ignore events if no dispatcher provided
        if (_dispatcher == null) return result;

        // dispatch events only if save was successful
        var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToArray();

        await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

        return result;
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }
}
