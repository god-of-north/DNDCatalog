using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace DNDCatalog.Core.SpellAggregate.Specifications;
public class SpellDetailsByShortNameSpec : Specification<Spell>, ISingleResultSpecification<Spell>
{
    public SpellDetailsByShortNameSpec(string shortName)
    {
        Query
            .Where(s => s.ShortName == shortName.ToLower())
            .Include(s => s.Archetypes)
            .Include(s => s.Classes);
    }
}
