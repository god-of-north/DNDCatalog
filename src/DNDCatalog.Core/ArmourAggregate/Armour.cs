using DNDCatalog.SharedKernel;
using DNDCatalog.SharedKernel.Interfaces;

namespace DNDCatalog.Core.ArmourAggregate;

public class Armour : EntityBase, IAggregateRoot
{
    public string NameUa { get; set; } = null!;
    public string NameRus { get; set; } = null!;
    public string NameEng { get; set; } = null!;
    public string DescriptionUa { get; set; } = null!;
    public string DescriptionRus { get; set; } = null!;
    public string DescriptionEng { get; set; } = null!;
    public string? Source { get; set; }
    public int Price { get; set; }
    public string ArmourClass { get; set; } = null!;
    public int Weight { get; set; }
    public bool StealthDisadvantage { get; set; }
    public int? StrengthRequirement { get; set;  }
    public ArmourType ArmourType { get; set; }

    //public DressingTime DressingTime { get; set; }    //depends on the ArmourType value
    //public DressingTime UndressingTime { get; set; }  //depends on the ArmourType value
}
