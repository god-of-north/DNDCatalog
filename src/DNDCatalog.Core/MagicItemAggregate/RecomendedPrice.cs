using DNDCatalog.SharedKernel;

namespace DNDCatalog.Core.MagicItemAggregate;

public class RecomendedPrice : ValueObject
{
    public int? MinPrice { get; set; }
    public int? MaxPrice { get; set; }
    public string? Notes { get; set; }
    public string? Formula { get; set; } // example: "((1d4 + 1) * 10000) / 2"
}