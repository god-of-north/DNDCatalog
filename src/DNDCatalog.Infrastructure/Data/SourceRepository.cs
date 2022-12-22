using Ardalis.Specification.EntityFrameworkCore;
using DNDCatalog.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DNDCatalog.Infrastructure.Data;
public class SourceRepository : ISourceRepository
{
    private readonly CatalogDbContext _db;

    public SourceRepository(CatalogDbContext dbContext)
    {
        _db = dbContext;
    }

    public async Task<IReadOnlyList<string?>> ListSourcesAsync(CancellationToken cancellationToken = default)
    {
        var spellsSources = await ListSpellsSourcesAsync(cancellationToken);
        var magicItemsSources = await ListMagicItemsSourcesAsync(cancellationToken);
        
        return spellsSources.Concat(magicItemsSources).Distinct().ToList();
    }

    public async Task<IReadOnlyList<string?>> ListSpellsSourcesAsync(CancellationToken cancellationToken = default)
    {
        return await _db.Spells
            .AsNoTracking()
            .Select(s => s.Source)
            .Where(s => s != null && s != "")
            .Distinct()
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<string?>> ListMagicItemsSourcesAsync(CancellationToken cancellationToken = default)
    {
        return await _db.MagicItems
            .AsNoTracking()
            .Select(s => s.Source)
            .Where(s => s != null && s != "")
            .Distinct()
            .ToListAsync(cancellationToken);
    }
}
