using AutoMapper;
using DNDCatalog.Core.MagicItemAggregate;
using DNDCatalog.Core.MagicItemAggregate.Specifications;
using Microsoft.ApplicationInsights.Extensibility.Implementation;

namespace DNDCatalog.Web.Endpoints.MagicItemEndpoints.Dtos;

public class MagicItemMapping : Profile
{
    public MagicItemMapping()
    {
        // Source -> Target
        CreateMap<MagicItem, MagicItemNameDto>()
            .ForCtorParam("Ukr", opt => opt.MapFrom(x => x.NameUa))
            .ForCtorParam("Eng", opt => opt.MapFrom(x => x.NameEng))
            .ForCtorParam("Rus", opt => opt.MapFrom(x => x.NameRus));

        CreateMap<MagicItem, MagicItemDescriptionDto>()
            .ForCtorParam("Ukr", opt => opt.MapFrom(x => x.DescriptionUa))
            .ForCtorParam("Ukr1", opt => opt.MapFrom(x => x.DescriptionUa1))
            .ForCtorParam("Ukr2", opt => opt.MapFrom(x => x.DescriptionUa2))
            .ForCtorParam("Rus1", opt => opt.MapFrom(x => x.DescriptionRus1))
            .ForCtorParam("Rus2", opt => opt.MapFrom(x => x.DescriptionRus2));

        CreateMap<MagicItem, MagicItemListItemDto>()
            .ForCtorParam("Name", opt=> opt.MapFrom(x => x));

        CreateMap<MagicItem, GetMagicItemByIdResponse>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(x => x));

        CreateMap<MagicItem, UpdateMagicItemResponse>();

        CreateMap<UpdateMagicItemRequest, MagicItem>()
            .ForMember(dest => dest.NameUa, opt => opt.MapFrom(x => x.Name))
            .ForMember(dest => dest.DescriptionUa, opt => opt.MapFrom(x => x.Description));

        CreateMap<MagicItemListRequest, FilterMagicItemListSpec>();
        CreateMap<MagicItemListRequest, FilterMagicItemListWithPagesSpec>();
    }
}

