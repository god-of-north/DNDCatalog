using DNDCatalog.Core.BaseEntities;
using DNDCatalog.Core.SpellAggregate;
using DNDCatalog.Web.Endpoints.SpellEndpoints.Dtos;

namespace DNDCatalog.Web.Endpoints.SpellEndpoints;

public class GetSpellByShortNameResponse
{
    public Guid Id { get; set; }
    public SpellNameDto Name { get; set; } = null!;
    public SpellDescriptionDto Description { get; set; } = null!;
    public int Level { get; set; }
    public List<ClassDto> Classes { get; set; } = new();
    public CastingTime? CastingTime { get; set; }
    public SpellSchool? School { get; set; }
    public SavingThrowType? SaveReqired { get; set; }
    public AttackType? Attack { get; set; }
    public DamageType? DamageType { get; set; }
    public EffectType? EffectType { get; set; }
    public bool Ritual { get; set; }
    public bool Concentration { get; set; }
    public bool ComponentV { get; set; }
    public bool ComponentS { get; set; }
    public bool ComponentM { get; set; }
    public string? ComponentMDescription { get; set; }
    public List<ArchetypeDto> Archetypes { get; set; } = new();
    public string? Source { get; set; }
    public SpellRange? Range { get; set; }
    public ActionDuration? Duration { get; set; }

}
