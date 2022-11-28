using DNDCatalog.Web.Endpoints.SpellEndpoints.Dtos;

namespace DNDCatalog.Web.Endpoints.SpellEndpoints;

public class SpellListResponse
{
    public List<SpellListItemDto> Spells { get; set; } = new();
    public int TotalCount { get; set; } = 0;
}
