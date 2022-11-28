using AutoMapper;
using DNDCatalog.Core.ClassAggregate;
using DNDCatalog.Core.Interfaces;
using DNDCatalog.Core.SpellAggregate;

namespace DNDCatalog.Web.Endpoints.SpellEndpoints.Dtos;

public class ArchetypeItemFromIdResolver : IValueResolver<UpdateSpellRequest, Spell, ICollection<Archetype>>
{
    private readonly IClassRepository _repository;
    public ArchetypeItemFromIdResolver(IClassRepository repository)
    {
        _repository = repository;
    }

    public ICollection<Archetype> Resolve(UpdateSpellRequest source, Spell destination, ICollection<Archetype> destMember, ResolutionContext context)
    {
        //var spec = new ArchetypesByIdsSpec(source.Archetypes);
        //var archetypes = _repository.ListAsync(spec).Result;
        var archetypes = _repository.GetArchetypesByIdsAsync(source.Archetypes).Result;

        return archetypes.ToList();
    }
}

