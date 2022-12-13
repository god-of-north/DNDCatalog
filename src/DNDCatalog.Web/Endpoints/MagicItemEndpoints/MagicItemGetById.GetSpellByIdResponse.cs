using DNDCatalog.Core.MagicItemAggregate;
using DNDCatalog.Web.Endpoints.MagicItemEndpoints.Dtos;

namespace DNDCatalog.Web.Endpoints.MagicItemEndpoints;

public class GetMagicItemByIdResponse
{
    public MagicItemNameDto Name { get; set; } = null!;
    public MagicItemDescriptionDto Description { get; set; } = null!;
    public string? Source { get; set; }
    public bool Attunement { get; set; }
    public int? MagicBonus { get; set; } 
    public MagicItemType Type { get; set; }
    public bool Consumable { get; set; }
    public bool Charged { get; set; } 
    public Rarity Rarity { get; set; }
    public RecomendedPrice? Price { get; set; }
}
