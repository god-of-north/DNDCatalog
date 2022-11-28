using Ardalis.Specification.EntityFrameworkCore;
using DNDCatalog.SharedKernel.Interfaces;

namespace DNDCatalog.Infrastructure.Data;
// inherit from Ardalis.Specification type
public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
  public EfRepository(CatalogDbContext dbContext) : base(dbContext)
  {
  }
}
