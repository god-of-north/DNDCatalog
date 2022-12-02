using DNDCatalog.Core.EquipmentItemAggregate;
using DNDCatalog.SharedKernel;
using DNDCatalog.SharedKernel.Interfaces;

namespace DNDCatalog.Core.BackgroundAggregate;

public class Background : EntityBase, IAggregateRoot
{
    public string NameUa { get; set; } = null!;
    public string NameRus { get; set; } = null!;
    public string NameEng { get; set; } = null!;
    public string DescriptionUa { get; set; } = null!;
    public string DescriptionRus { get; set; } = null!;
    public string DescriptionEng { get; set; } = null!;
    public string PersonalizationUa { get; set; } = null!;
    public string PersonalizationRus { get; set; } = null!;
    public string PersonalizationEng { get; set; } = null!;
    public string ToolsUa { get; set; } = null!;
    public string ToolsRus { get; set; } = null!;
    public string ToolsEng { get; set; } = null!;
    public string? Source { get; set; }
    public List<Skill>? Skills { get; set; }
    public List<EquipmentItem> Equipments { get; set; } = null!;
    public int StartingMoney { get; set; }
}
