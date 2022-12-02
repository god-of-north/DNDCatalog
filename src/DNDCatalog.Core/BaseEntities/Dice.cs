using DNDCatalog.SharedKernel;

namespace DNDCatalog.Core.BaseEntities;

/// <summary>
/// Dice Value Object
/// Format: [Multiplyer]d[SideCount]
/// Example:
///     for dice 1d20:
///     - Multiplyer = 1
///     - SideCount = 20
/// </summary>
public class Dice : ValueObject
{
    public int Multiplyer { get; set; }
    public int SideCount { get; set; }

    public override string? ToString()
    {
        return $"{Multiplyer}d{SideCount}";
    }
}
