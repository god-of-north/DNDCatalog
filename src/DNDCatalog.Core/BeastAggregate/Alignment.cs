using DNDCatalog.SharedKernel;

namespace DNDCatalog.Core.BeastAggregate;

public class Alignment: ValueObject
{
    public LawVsChaos LawVsChaos { get; set; }
    public GoodVsEvil GoodVsEvil { get; set; }


}