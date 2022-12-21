using DNDCatalog.Web.Endpoints.ArchetypeEndpoints.Dtos;

namespace DNDCatalog.Web.Endpoints.ArchetypeEndpoints;

public class ArchetypeListResponse
{
    public List<ArchetypeListItemDto> Archetypes { get; set; } = new();
}
