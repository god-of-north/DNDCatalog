using DNDCatalog.SharedKernel;

namespace DNDCatalog.Core.BeastAggregate;

public class Ability : ValueObject
{
    public int Charisma { get; set; }
    public int Constitution { get; set; }
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Intelligence { get; set; }
    public int Wizdom { get; set; }
}