
namespace DNDCatalog.Core.Interfaces;

public interface ISourceRepository
{
    Task<IReadOnlyList<string?>> ListSourcesAsync(CancellationToken cancellationToken);
}
