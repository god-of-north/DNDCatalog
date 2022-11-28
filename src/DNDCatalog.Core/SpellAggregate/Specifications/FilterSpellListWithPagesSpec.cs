using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace DNDCatalog.Core.SpellAggregate.Specifications;
public class FilterSpellListWithPagesSpec : FilterSpellListSpec
{
    public FilterSpellListWithPagesSpec(
        int page,
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
        Guid[]? archetypes
        ) : base(ritual,concentration,verbal,somatic,material,levels,sources,attackTypes,damageTypes,effectTypes,savingThrowTypes,schools,classes,archetypes)
    {
        Query
            .Skip(page * SpellConstants.SpellsOnPage)
            .Take(SpellConstants.SpellsOnPage)
            .AsNoTracking()
            ;
    }
}
