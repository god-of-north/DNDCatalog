using System.ComponentModel.DataAnnotations;
using DNDCatalog.Core.BaseEntities;
using DNDCatalog.Core.SpellAggregate;


namespace DNDCatalog.Web.Endpoints.SpellEndpoints;


public class UpdateSpellRequest
{
    [Required]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; } 
    public int? Level { get; set; }
    public bool? Ritual { get; set; }
    public bool? Concentration { get; set; }
    public bool? Verbal { get; set; }
    public bool? Somatic { get; set; }
    public bool? Material { get; set; }
    public string? MaterialDescription { get; set; }
    public string? Source { get; set; }
    public AttackType? AttackType { get; set; }
    public DamageType? DamageType { get; set; }
    public EffectType? EffectType { get; set; }
    public SavingThrowType? SavingThrowType { get; set; }
    public SpellSchool? School { get; set; }
    public CastingTime? CastingTime { get; set; }
    public SpellRange? Range { get; set; }
    public ActionDuration? Duration { get; set; }
    public List<Guid>? Classes { get; set; }
    public List<Guid>? Archetypes { get; set; }

}
