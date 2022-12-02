namespace DNDCatalog.Core.WeaponAggregate;

public abstract class RangeWeaponProperty : WeaponProperty
{
    public RangeWeaponProperty(WeaponPropertyType weaponPropertyType) : base(weaponPropertyType)
    {
    }

    public int OptimalDistance { get; set; }
    public int MaxDistance { get; set; }
}

