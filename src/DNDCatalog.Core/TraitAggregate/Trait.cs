using DNDCatalog.SharedKernel;
using DNDCatalog.SharedKernel.Interfaces;

namespace DNDCatalog.Core.TraitAggregate;

public class Trait : EntityBase, IAggregateRoot
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
