using DNDCatalog.SharedKernel;
using DNDCatalog.SharedKernel.Interfaces;

namespace DNDCatalog.Core.SourceAggregate;

public class Source : EntityBase, IAggregateRoot
{
    public string Name { get; set; } = null!;
    public bool IsHomebrew { get; set; }
}
