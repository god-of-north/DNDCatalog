using DNDCatalog.SharedKernel;
using DNDCatalog.SharedKernel.Interfaces;

namespace DNDCatalog.Core.MagicItemAggregate;


public class MagicItem : EntityBase, IAggregateRoot
{
    public string NameUa { get; set; } = null!;
    public string NameRus { get; set; } = null!;
    public string NameEng { get; set; } = null!;
    public string DescriptionUa { get; set; } = null!;
    public string DescriptionRus { get; set; } = null!;
    public string DescriptionEng { get; set; } = null!;
    public string? Source { get; set; }
    public bool RequiresAttunement { get; set; }
    public int MagicBonus { get; set; }
    public MagicItemType Type { get; set; }
    public bool Consumable { get; set; } // Витратний матеріал
    public bool Charged { get; set; } // Має заряд
    public Rarity Rarity { get; set; }
}
