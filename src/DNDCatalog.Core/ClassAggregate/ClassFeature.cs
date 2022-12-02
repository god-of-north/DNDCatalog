using DNDCatalog.SharedKernel;
using DNDCatalog.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNDCatalog.Core.ClassAggregate;

public class ClassFeature : EntityBase, IAggregateRoot
{
    public string NameUa { get; set; } = null!;
    public string NameRus { get; set; } = null!;
    public string NameEng { get; set; } = null!;
    public string DescriptionUa { get; set; } = null!;
    public string DescriptionRus { get; set; } = null!;
    public string DescriptionEng { get; set; } = null!;
    public string? Source { get; set; }
    public string? Requirements { get; set; }


}
