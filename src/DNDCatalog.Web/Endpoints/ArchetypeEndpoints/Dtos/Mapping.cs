using AutoMapper;
using DNDCatalog.Core.ClassAggregate;

namespace DNDCatalog.Web.Endpoints.ArchetypeEndpoints.Dtos;

public class Mapping : Profile
{
    public Mapping()
    {
        // Source -> Target
        CreateMap<Archetype, ArchetypeListItemDto>()
            .ForMember(dest => dest.ClassId, opt => opt.MapFrom(a=>a.Class.Id));
    }
}
