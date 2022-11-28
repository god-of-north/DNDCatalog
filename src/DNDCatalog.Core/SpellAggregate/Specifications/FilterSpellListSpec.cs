using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace DNDCatalog.Core.SpellAggregate.Specifications;
public class FilterSpellListSpec : Specification<Spell>
{
    /*
    CastingTime? CastingTime,
    SpellRange? Range,
    ActionDuration? Duration,
     
     */

    public FilterSpellListSpec(
        bool? ritual,
        bool? concentration,
        bool? verbal,
        bool? somatic,
        bool? material,
        int[]? levels,
        string[]? sources,
        AttackType[]? attackTypes,
        DamageType[]? damageTypes,
        EffectType[]? effectTypes,
        SavingThrowType[]? savingThrowTypes,
        SpellSchool[]? schools,
        Guid[]? classes,
        Guid[]? archetypes)
    {
        Query.AsNoTracking();

        if (ritual is not null) Query.Where(s => s.Ritual == ritual);
        if (concentration is not null) Query.Where(s => s.Concentration == concentration);
        if (verbal is not null) Query.Where(s => s.ComponentV == verbal);
        if (somatic is not null) Query.Where(s => s.ComponentS == somatic);
        if (material is not null) Query.Where(s => s.ComponentM == material);
        if (levels is not null && levels.Length>0) Query.Where(s => levels.Contains(s.Level));
        if (sources is not null && sources.Length>0) Query.Where(s => sources.Contains(s.Source));
        if (attackTypes is not null && attackTypes.Length>0) Query.Where(s => s.Attack!=null && attackTypes.Contains((AttackType)s.Attack));
        if (damageTypes is not null && damageTypes.Length>0) Query.Where(s => s.DamageType!=null && damageTypes.Contains((DamageType)s.DamageType));
        if (effectTypes is not null && effectTypes.Length>0) Query.Where(s => s.EffectType!=null && effectTypes.Contains((EffectType)s.EffectType));
        if (savingThrowTypes is not null && savingThrowTypes.Length>0) Query.Where(s => s.SaveReqired!=null && savingThrowTypes.Contains((SavingThrowType)s.SaveReqired));
        if (schools is not null && schools.Length>0) Query.Where(s => s.School!=null && schools.Contains((SpellSchool)s.School));

        if (classes is not null && classes.Length > 0) 
            Query
                .Include(s => s.Classes)
                .Where(s => s.Classes.Select(c => c.Id).Any(c=>classes.Contains(c)));

        if (archetypes is not null && archetypes.Length>0) 
            Query
                .Include(s => s.Archetypes)
                .Where(s => s.Archetypes.Select(a => a.Id).Any(a => archetypes.Contains(a)));
    }
}
