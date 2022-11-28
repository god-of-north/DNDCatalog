using AutoMapper;
using DNDCatalog.Core.ClassAggregate;
using DNDCatalog.Core.ClassAggregate.Specifications;
using DNDCatalog.Core.SpellAggregate;
using DNDCatalog.SharedKernel.Interfaces;

namespace DNDCatalog.Web.Endpoints.SpellEndpoints.Dtos;

public class ClassItemFromIdResolver : IValueResolver<UpdateSpellRequest, Spell, ICollection<Class>>
{
    private readonly IRepository<Class> _repository;
    public ClassItemFromIdResolver(IRepository<Class> repository)
    {
        _repository = repository;
    }

    public ICollection<Class> Resolve(UpdateSpellRequest source, Spell destination, ICollection<Class> destMember, ResolutionContext context)
    {
        var spec = new ClassesByIdsSpec(source.Classes);
        var classes = _repository.ListAsync(spec).Result;

        return classes;
    }
}

