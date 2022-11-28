using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace DNDCatalog.Core.SpellAggregate.Specifications;
public class SpellDetailsByIdSpec : Specification<Spell>, ISingleResultSpecification<Spell>
{
    public SpellDetailsByIdSpec(Guid spellId)
    {
        Query
            .Where(s => s.Id == spellId)
            .Include(s => s.Archetypes)
            .Include(s => s.Classes);
    }
}
