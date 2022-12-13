using DNDCatalog.Core.HashtagAggregate;
using DNDCatalog.SharedKernel;
using DNDCatalog.SharedKernel.Interfaces;

namespace DNDCatalog.Core.MagicItemAggregate;


public class MagicItem : EntityBase, IAggregateRoot
{
    public string NameUa { get; set; } = null!;
    public string NameRus { get; set; } = null!;
    public string NameEng { get; set; } = null!;
    public string DescriptionUa { get; set; } = null!;
    public string DescriptionUa1 { get; set; } = null!;
    public string DescriptionUa2 { get; set; } = null!;
    public string DescriptionRus1 { get; set; } = null!;
    public string DescriptionRus2 { get; set; } = null!;
    public string? Source { get; set; }
    public bool Attunement { get; set; }
    public int? MagicBonus { get; set; } // +1, +2, +3...
    public MagicItemType Type { get; set; }
    public bool Consumable { get; set; } // Витратний матеріал
    public bool Charged { get; set; } // Має заряд
    public Rarity Rarity { get; set; }
    public RecomendedPrice? Price { get; set; }
    public List<Hashtag> Hashtags { get; set; } = null!;
}
