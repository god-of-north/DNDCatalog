using DNDCatalog.SharedKernel;

namespace DNDCatalog.Core.WeaponAggregate;


public abstract class WeaponProperty : EntityBase
{
    public readonly WeaponPropertyType PropertyType;

    protected WeaponProperty(WeaponPropertyType weaponPropertyType)
    {
        PropertyType = weaponPropertyType;
    }

    public string Description { get; set; } = null!;
}
