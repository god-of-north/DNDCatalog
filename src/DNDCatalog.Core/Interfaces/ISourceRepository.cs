
namespace DNDCatalog.Core.Interfaces;

public interface ISourceRepository
{
    /// <summary>
    /// Get All Sources
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of sources</returns>
    Task<IReadOnlyList<string?>> ListSourcesAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Get Sources for Spells only
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of Sources for spells</returns>
    Task<IReadOnlyList<string?>> ListSpellsSourcesAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Get Sources for MagicItems only
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of Sources for Magic Items</returns>
    Task<IReadOnlyList<string?>> ListMagicItemsSourcesAsync(CancellationToken cancellationToken);
}
