namespace DNDCatalog.Core.SpellAggregate;

public class SpellRange
{
  public RangeType Type { get; set; }
  public int? Distance { get; set; }
  public int? Area { get; set; }
  public AreaShape? Shape { get; set; }

}
