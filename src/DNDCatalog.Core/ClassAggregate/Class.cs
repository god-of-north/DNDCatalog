using DNDCatalog.SharedKernel.Interfaces;
using DNDCatalog.SharedKernel;
using DNDCatalog.Core.SpellAggregate;

namespace DNDCatalog.Core.ClassAggregate;

public class Class: EntityBase, IAggregateRoot
{
  public string Name { get; set; } = null!;
  public string Description { get; set; } = null!;
  public ICollection<Archetype>? Archetypes { get; set; }
  public ICollection<Spell>? Spells { get; set; }
}
