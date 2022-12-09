using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using DNDCatalog.Core.BaseEntities;
using DNDCatalog.Core.ClassAggregate;
using DNDCatalog.Core.SpellAggregate;
using DNDCatalog.SharedKernel.Interfaces;

namespace DNDCatalog.Core.Interfaces;
public interface ISpellRepository : IReadRepository<Spell>, IRepository<Spell>
{
    Task<ICollection<Class>> GetClassesByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
    Task<Spell> GetByIdWithDependeciesAsync(Guid id, CancellationToken cancellationToken = default);
    Task<int> GetCountOfFiltredSpellsAsync(CancellationToken cancellationToken);
    Task<List<Spell>> SearchByNameWithFilterAsync(Specification<Spell> filterSpec, string? search = null, CancellationToken cancellationToken = default);
    Task<int> SearchByNameWithFilterCountAsync(Specification<Spell> filterSpec, string? search = null, CancellationToken cancellationToken = default);
}
