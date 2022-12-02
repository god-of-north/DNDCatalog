using DNDCatalog.Core.BaseEntities;

namespace DNDCatalog.Core.WeaponAggregate;

public class VersatileWeaponProperty : WeaponProperty
{
    public VersatileWeaponProperty() : base(WeaponPropertyType.Versatile)
    {
    }

    public Dice TwoHndedDamageDice { get; set; } = null!;
}

