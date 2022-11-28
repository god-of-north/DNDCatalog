using DNDCatalog.SharedKernel.Interfaces;
using DNDCatalog.SharedKernel;
using DNDCatalog.Core.SpellAggregate;

namespace DNDCatalog.Core.ClassAggregate;

public class Archetype : EntityBase
{
    public string Name { get; set; } = null!;
    public Class Class { get; set; } = null!;
    public ICollection<Spell>? Spells { get; set; }

}
