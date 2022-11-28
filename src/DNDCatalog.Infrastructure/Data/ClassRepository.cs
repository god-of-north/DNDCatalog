using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification.EntityFrameworkCore;
using DNDCatalog.Core.ClassAggregate;
using DNDCatalog.Core.Interfaces;
using DNDCatalog.Core.SpellAggregate;
using DNDCatalog.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DNDCatalog.Infrastructure.Data;
public class ClassRepository : RepositoryBase<Spell>, IClassRepository
{
    private readonly CatalogDbContext _db;

    public ClassRepository(CatalogDbContext dbContext) : base(dbContext)
    {
        _db = dbContext;
    }

    public async Task<IList<Archetype>> ListArchetypesAsync(CancellationToken cancellationToken = default)
    {
        return await _db.Archetypes.ToListAsync(cancellationToken);
    }

    public async Task<IList<Class>> ListClassesAsync(CancellationToken cancellationToken = default)
    {
        return await _db.Classes.ToListAsync(cancellationToken);
    }

    public async Task<IList<Class>> GetClassesByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
    {
        return await _db.Classes
            .Where(c => ids.Contains(c.Id))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Archetype>> GetArchetypesByIdsAsync(List<Guid> archetypes, CancellationToken cancellationToken = default)
    {
        return await _db.Archetypes
            .Where(c => archetypes.Contains(c.Id))
            .ToListAsync(cancellationToken);
    }
}
