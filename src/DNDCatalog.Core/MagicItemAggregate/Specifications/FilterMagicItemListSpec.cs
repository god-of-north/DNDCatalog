using Ardalis.Specification;

namespace DNDCatalog.Core.MagicItemAggregate.Specifications;
public class FilterMagicItemListSpec : Specification<MagicItem>
{
    public FilterMagicItemListSpec(
        Rarity[]? rarities,
        MagicItemType[]? types,
        int? priceMin,
        int? priceMax,
        string[]? sources,
        bool? attunement,
        int[]? magicBonuses,
        bool? consumable,
        bool? charged)
    {
        Query.AsNoTracking();

        if (attunement is not null) Query.Where(s => s.Attunement == attunement);
        if (consumable is not null) Query.Where(s => s.Consumable == consumable);
        if (charged is not null) Query.Where(s => s.Charged == charged);
        if (priceMin is not null && priceMin > 0) Query.Where(s => s.Price!.MaxPrice >= priceMin );
        if (priceMax is not null && priceMax > 0 && priceMax > (priceMin ?? 0)) Query.Where(s => s.Price!.MinPrice <= priceMax);
        if (sources is not null && sources.Length > 0) Query.Where(s => sources.Contains(s.Source));
        if (magicBonuses is not null && magicBonuses.Length > 0) Query.Where(s => s.MagicBonus != null && magicBonuses.Contains((int)s.MagicBonus));
        if (types is not null && types.Length > 0) Query.Where(s => types.Contains(s.Type));
        if (rarities is not null && rarities.Length > 0) Query.Where(s => rarities.Contains(s.Rarity));
    }
}
