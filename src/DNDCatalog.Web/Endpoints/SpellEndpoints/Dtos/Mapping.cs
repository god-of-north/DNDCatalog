using AutoMapper;
using DNDCatalog.Core.ClassAggregate;
using DNDCatalog.Core.SpellAggregate;
using DNDCatalog.Core.SpellAggregate.Specifications;
using Microsoft.ApplicationInsights.Extensibility.Implementation;

namespace DNDCatalog.Web.Endpoints.SpellEndpoints.Dtos;

public class Mapping : Profile
{
    public Mapping()
    {
        // Source -> Target
        CreateMap<Spell, SpellNameDto>()
            .ForCtorParam("Ukr", opt => opt.MapFrom(x => x.NameUa))
            .ForCtorParam("Eng", opt => opt.MapFrom(x => x.NameEng))
            .ForCtorParam("Rus", opt => opt.MapFrom(x => x.NameRus));

        CreateMap<Spell, SpellListItemDto>()
            .ForCtorParam("Name", opt=> opt.MapFrom(x => x));

        CreateMap<Spell, SpellDescriptionDto>()
            .ForCtorParam("Ukr1", opt => opt.MapFrom(x => x.DescriptionUa1))
            .ForCtorParam("Ukr2", opt => opt.MapFrom(x => x.DescriptionUa2))
            .ForCtorParam("Ukr3", opt => opt.MapFrom(x => x.DescriptionUa3))
            .ForCtorParam("Eng", opt => opt.MapFrom(x => x.DescriptionEng))
            .ForCtorParam("Rus1", opt => opt.MapFrom(x => x.DescriptionRu1))
            .ForCtorParam("Rus2", opt => opt.MapFrom(x => x.DescriptionRu2));

        CreateMap<Class, ClassDto>();

        CreateMap<Archetype, ArchetypeDto>();

        CreateMap<Spell, GetSpellByIdResponse>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(x => x));

        CreateMap<Spell, UpdateSpellResponse>();

        CreateMap<UpdateSpellRequest, Spell>()
            .ForMember(dest => dest.NameUa, opt => opt.MapFrom(x => x.Name))
            .ForMember(dest => dest.DescriptionUa1, opt => opt.MapFrom(x => x.Description))
            .ForMember(dest => dest.ComponentV, opt => opt.MapFrom(x => x.Verbal))
            .ForMember(dest => dest.ComponentS, opt => opt.MapFrom(x => x.Somatic))
            .ForMember(dest => dest.ComponentM, opt => opt.MapFrom(x => x.Material))
            .ForMember(dest => dest.ComponentMDescription, opt => opt.MapFrom(x => x.MaterialDescription))
            .ForMember(dest => dest.Attack, opt => opt.MapFrom(x => x.AttackType))
            .ForMember(dest => dest.SaveReqired, opt => opt.MapFrom(x => x.SavingThrowType))
            .ForMember(dest => dest.SaveReqired, opt => opt.MapFrom(x => x.SavingThrowType))
            .ForMember(dest => dest.Archetypes, opt => opt.MapFrom<ArchetypeItemFromIdResolver>())
            .ForMember(dest => dest.Classes, opt => opt.MapFrom<ClassItemFromIdResolver>())
            ;

        CreateMap<SpellListRequest, FilterSpellListSpec>();
        CreateMap<SpellListRequest, FilterSpellListWithPagesSpec>();
    }
}

