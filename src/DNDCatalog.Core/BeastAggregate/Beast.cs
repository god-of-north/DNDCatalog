using DNDCatalog.SharedKernel;
using DNDCatalog.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNDCatalog.Core.BeastAggregate;

public class Beast : EntityBase, IAggregateRoot
{
    public string NameUa { get; set; } = null!;
    public string NameRus { get; set; } = null!;
    public string NameEng { get; set; } = null!;
    public string DescriptionUa { get; set; } = null!;
    public string DescriptionRus { get; set; } = null!;
    public string DescriptionEng { get; set; } = null!;
    public string? Source { get; set; }
    public int ArmourClass { get; set; }
    public string? ArmourClassNotes { get; set; }
    public Ability Ability { get; set; } = null!;
    public Alignment? Alignment { get; set; }
    public int? Experience { get; set; }
    public BeastSize Size { get; set; }
    public List<BeastSpeed> Speeds { get; set; } = null!;
    

}
