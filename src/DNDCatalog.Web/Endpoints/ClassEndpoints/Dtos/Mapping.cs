using AutoMapper;
using DNDCatalog.Core.ClassAggregate;
using DNDCatalog.Web.Endpoints.SpellEndpoints.Dtos;

namespace DNDCatalog.Web.Endpoints.ClassEndpoints.Dtos;

public class Mapping : Profile
{
    public Mapping()
    {
        // Source -> Target
        CreateMap<Class, ClassListItemDto>();
    }
}
