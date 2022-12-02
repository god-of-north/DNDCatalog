using DNDCatalog.Core.BaseEntities;

namespace DNDCatalog.Core.SpellAggregate;

public class CastingTime
{
  public bool IsAction { get; set; }

  public ActionTime? ActionTime { get; set; }

  public TimeSpan? Time { get; set; }

}
