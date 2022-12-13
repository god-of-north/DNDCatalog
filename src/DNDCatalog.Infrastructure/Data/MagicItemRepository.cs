using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using DNDCatalog.Core.Interfaces;
using DNDCatalog.Core.MagicItemAggregate;
using DNDCatalog.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DNDCatalog.Infrastructure.Data;
public class MagicItemRepository : RepositoryBase<MagicItem>, IMagicItemRepository
{
    private readonly CatalogDbContext _db;
    private readonly ISpecificationEvaluator _specificationEvaluator = SpecificationEvaluator.Default;

    public MagicItemRepository(CatalogDbContext dbContext): base(dbContext, SpecificationEvaluator.Default)
    {
        _db = dbContext;
    }

    private static IQueryable<MagicItem> AddSearchByNameToQuery(IQueryable<MagicItem> query, string? search)
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

    public async Task<List<MagicItem>> SearchByNameWithFilterAsync(Specification<MagicItem> filterSpec, string? search = null, CancellationToken cancellationToken = default)
    {
        var query = AddSearchByNameToQuery(_db.MagicItems.AsQueryable(), search);
        query = _specificationEvaluator.GetQuery(query, filterSpec);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<int> SearchByNameWithFilterCountAsync(Specification<MagicItem> filterSpec, string? search = null, CancellationToken cancellationToken = default)
    {
        var query = AddSearchByNameToQuery(_db.MagicItems.AsQueryable(), search);
        query = _specificationEvaluator.GetQuery(query, filterSpec);

        return await query.CountAsync(cancellationToken);
    }
}
