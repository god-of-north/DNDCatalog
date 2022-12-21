using DNDCatalog.Web.Endpoints.ClassEndpoints.Dtos;

namespace DNDCatalog.Web.Endpoints.ClassEndpoints;

public class ClassListResponse
{
    public List<ClassListItemDto> Classes { get; set; } = new();
}
