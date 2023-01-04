using DNDCatalog.Core.ClassAggregate;
using DNDCatalog.SharedKernel.Interfaces;
using DNDCatalog.SharedKernel;
using DNDCatalog.Core.BaseEntities;

namespace DNDCatalog.Core.SpellAggregate;

public class Spell : EntityBase, IAggregateRoot
{
    public string? ShortName { get; set; } = null!;
    public string NameUa { get; set; } = null!;
    public string NameRus { get; set; } = null!;
    public string NameEng { get; set; } = null!;
    public string DescriptionEng { get; set; } = null!;
    public string DescriptionUa1 { get; set; } = null!;
    public string DescriptionUa2 { get; set; } = null!;
    public string DescriptionUa3 { get; set; } = null!;
    public string DescriptionRu1 { get; set; } = null!;
    public string DescriptionRu2 { get; set; } = null!;
    public int Level { get; set; }
    public ICollection<Class>? Classes { get; set; } = null!;
    public ICollection<SpellTag> Tags { get; set; } = null!;
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
    public ICollection<Archetype>? Archetypes { get; set; }
    public string? Source { get; set; }
    public SpellRange? Range { get; set; }
    public ActionDuration? Duration { get; set; }
}
