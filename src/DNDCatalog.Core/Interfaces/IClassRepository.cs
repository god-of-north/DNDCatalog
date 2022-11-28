using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNDCatalog.Core.ClassAggregate;
using DNDCatalog.Core.SpellAggregate;
using DNDCatalog.SharedKernel.Interfaces;

namespace DNDCatalog.Core.Interfaces;
public interface IClassRepository : IReadRepository<Spell>, IRepository<Spell>
{
    Task<IList<Archetype>> ListArchetypesAsync(CancellationToken cancellationToken = default);
    Task<IList<Class>> ListClassesAsync(CancellationToken cancellationToken = default);
    Task<IList<Class>> GetClassesByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Archetype>> GetArchetypesByIdsAsync(List<Guid> archetypes, CancellationToken cancellationToken = default);
}
