using DNDCatalog.Core.SpellAggregate;

namespace DNDCatalog.Web.Endpoints.SpellEndpoints.Dtos;

public record SpellListItemDto(
    Guid Id, 
    SpellNameDto Name, 
    string Source, 
    int Level,
    SpellSchool School,
    bool Ritual,
    bool Concentration,
    bool ComponentV,
    bool ComponentS,
    bool ComponentM
    );
