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

    public async Task<IReadOnlyList<string?>> ListSourcesAsync(CancellationToken cancellationToken)
    {
        return await _db.Spells
            .AsNoTracking()
            .Select(s => s.Source)
            .Where(s => s != null && s != "")
            .Distinct()
            .ToListAsync(cancellationToken);

    }
}
