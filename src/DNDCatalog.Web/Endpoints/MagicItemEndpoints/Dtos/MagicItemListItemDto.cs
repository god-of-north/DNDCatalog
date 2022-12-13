
using DNDCatalog.Core.MagicItemAggregate;

namespace DNDCatalog.Web.Endpoints.MagicItemEndpoints.Dtos;

public record MagicItemListItemDto(
    Guid Id,
    MagicItemNameDto Name,
    string Source,
    MagicItemType Type,
    Rarity Rarity,
    bool Attunement
    );
