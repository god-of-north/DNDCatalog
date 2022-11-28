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
public class SpellRepository : RepositoryBase<Spell>, ISpellRepository
{
    private readonly CatalogDbContext _db;

    public SpellRepository(CatalogDbContext dbContext) : base(dbContext)
    {
        _db = dbContext;
    }

    public async Task<Spell> GetByIdWithDependeciesAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _db.Spells
            .Where(s => s.Id == id)
            .Include(s => s.Classes)
            .Include(s => s.Archetypes)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<ICollection<Class>> GetClassesByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
    {
        return await _db.Classes.Where(c => ids.Contains(c.Id)).ToListAsync(cancellationToken);
    }

    public async Task<int> GetCountOfFiltredSpellsAsync(CancellationToken cancellationToken)
    {
        return await _db.Spells.CountAsync(cancellationToken);
    }
}
