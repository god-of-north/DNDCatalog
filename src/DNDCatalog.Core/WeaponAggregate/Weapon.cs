using DNDCatalog.Core.BaseEntities;
using DNDCatalog.SharedKernel;
using DNDCatalog.SharedKernel.Interfaces;

namespace DNDCatalog.Core.WeaponAggregate;

public class Weapon : EntityBase, IAggregateRoot
{
    public string NameUa { get; set; } = null!;
    public string NameRus { get; set; } = null!;
    public string NameEng { get; set; } = null!;
    public string DescriptionUa { get; set; } = null!;
    public string DescriptionRus { get; set; } = null!;
    public string DescriptionEng { get; set; } = null!;
    public string? Source { get; set; }
    public int Price { get; set; }
    public int? Weight { get; set; }
    public Dice? DamageDice { get; set; }
    public DamageType? DamageType { get; set; }
    public List<WeaponProperty>? Properties { get; set; }
}
