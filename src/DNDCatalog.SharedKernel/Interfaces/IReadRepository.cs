using Ardalis.Specification;

namespace DNDCatalog.SharedKernel.Interfaces;
public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
