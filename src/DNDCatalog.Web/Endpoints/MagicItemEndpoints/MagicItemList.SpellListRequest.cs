using DNDCatalog.Core.MagicItemAggregate;

namespace DNDCatalog.Web.Endpoints.MagicItemEndpoints;

public class MagicItemListRequest
{
    public int Page { get; set; } = 0;
    public string? Search { get; set; }

    public Rarity[]? Rarities { get; set; }
    public MagicItemType[]? Types { get; set; }
    public int? PriceMin { get; set; }
    public int? PriceMax { get; set; }
    public string[]? Sources { get; set; }
    public bool? Attunement { get; set; }
    public int[]? MagicBonuses { get; set; }
    public bool? Consumable { get; set; }
    public bool? Charged { get; set; }

}
