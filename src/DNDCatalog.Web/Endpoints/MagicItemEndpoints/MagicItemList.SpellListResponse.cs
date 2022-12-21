using DNDCatalog.Web.Endpoints.MagicItemEndpoints.Dtos;

namespace DNDCatalog.Web.Endpoints.MagicItemEndpoints;


public class MagicItemListResponse
{
    public List<MagicItemListItemDto> MagicItems { get; set; } = new();
    public int TotalCount { get; set; } = 0;
}
