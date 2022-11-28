using DNDCatalog.SharedKernel;

namespace DNDCatalog.Core.SpellAggregate;

public class SpellTag : EntityBase
{
  public string Name { get; set; } = null!;
  public List<Spell> Spells { get; set; } = null!;
}
