using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace DNDCatalog.Core.SpellAggregate.Specifications;

public class SourceListSpec : Specification<Spell, string?>
{
    public SourceListSpec()
    {
        Query
            .Select(s => s.Source)
            .Where(s => s.Source != null && s.Source != "")
            ;
    }
}
