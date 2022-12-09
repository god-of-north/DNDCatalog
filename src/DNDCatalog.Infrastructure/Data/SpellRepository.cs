using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using DNDCatalog.Core.BaseEntities;
using DNDCatalog.Core.ClassAggregate;
using DNDCatalog.Core.Interfaces;
using DNDCatalog.Core.SpellAggregate;
using DNDCatalog.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DNDCatalog.Infrastructure.Data;
public class SpellRepository : RepositoryBase<Spell>, ISpellRepository
{
    private readonly CatalogDbContext _db;
    private readonly ISpecificationEvaluator _specificationEvaluator = SpecificationEvaluator.Default;

    public SpellRepository(CatalogDbContext dbContext): base(dbContext, SpecificationEvaluator.Default)
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

    public async Task<List<Spell>> SearchByNameWithFilterAsync(Specification<Spell> filterSpec, string? search = null, CancellationToken cancellationToken = default)
    {
        var query = AddSearchByNameToQuery(_db.Spells.AsQueryable(), search);
        query = _specificationEvaluator.GetQuery(query, filterSpec);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<int> SearchByNameWithFilterCountAsync(Specification<Spell> filterSpec, string? search = null, CancellationToken cancellationToken = default)
    {
        var query = AddSearchByNameToQuery(_db.Spells.AsQueryable(), search);
        query = _specificationEvaluator.GetQuery(query, filterSpec);

        return await query.CountAsync(cancellationToken);
    }

    private static IQueryable<Spell> AddSearchByNameToQuery(IQueryable<Spell> query, string? search)
    {
        if (String.IsNullOrWhiteSpace(search))
            return query;

        search = search
            .Replace("%", "[%]")
            .Replace("_", "[_]")
            .Replace("[", "[[]");
        query = query.Where(s => EF.Functions.Like(s.NameUa, $"%{search}%") || EF.Functions.Like(s.NameEng, $"%{search}%"));

        return query;
    }


}
