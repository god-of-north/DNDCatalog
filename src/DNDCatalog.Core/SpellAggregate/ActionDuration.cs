namespace DNDCatalog.Core.SpellAggregate;

public class ActionDuration
{
  public ActionDurationType Type { get; set; }
  public TimeSpan? Time { get; set; } // 1 round == 6 seconds

}
