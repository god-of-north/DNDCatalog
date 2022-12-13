using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using DNDCatalog.Core.BaseEntities;

namespace DNDCatalog.Core.MagicItemAggregate.Specifications;
public class FilterMagicItemListWithPagesSpec : FilterMagicItemListSpec
{
    public FilterMagicItemListWithPagesSpec(
        int page,
        Rarity[]? rarities,
        MagicItemType[]? types,
        int? priceMin,
        int? priceMax,
        string[]? sources,
        bool? attunement,
        int[]? magicBonuses,
        bool? consumable,
        bool? charged
        ) : base( rarities, types, priceMin, priceMax, sources, attunement, magicBonuses, consumable, charged)
    {
        Query
            .Skip(page * MagicItemConstants.MagicItemsOnPage)
            .Take(MagicItemConstants.MagicItemsOnPage)
            .AsNoTracking()
            ;
    }
}
