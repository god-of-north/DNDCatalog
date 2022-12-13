using Ardalis.Specification;
using DNDCatalog.Core.MagicItemAggregate;
using DNDCatalog.SharedKernel.Interfaces;

namespace DNDCatalog.Core.Interfaces;
public interface IMagicItemRepository : IReadRepository<MagicItem>, IRepository<MagicItem>
{
    Task<List<MagicItem>> SearchByNameWithFilterAsync(Specification<MagicItem> filterSpec, string? search = null, CancellationToken cancellationToken = default);
    Task<int> SearchByNameWithFilterCountAsync(Specification<MagicItem> filterSpec, string? search = null, CancellationToken cancellationToken = default);
}
