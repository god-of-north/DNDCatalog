using DNDCatalog.Core.SpellAggregate;

namespace DNDCatalog.Web.Endpoints.SpellEndpoints;

public class SpellListRequest
{
    public int Page { get; set; } = 0;

    public bool? Ritual { get; set; }
    public bool? Concentration {get; set;}
    public bool? Verbal {get; set;}
    public bool? Somatic {get; set;}
    public bool? Material {get; set;}
    public int[]? Levels {get; set;}
    public string[]? Sources {get; set;}
    public AttackType[]? AttackTypes {get; set;}
    public DamageType[]? DamageTypes {get; set;}
    public EffectType[]? EffectTypes {get; set;}
    public SavingThrowType[]? SavingThrowTypes {get; set;}
    public SpellSchool[]? Schools {get; set;}
    public Guid[]? Classes {get; set;}
    public Guid[]? Archetypes {get; set;}
}
