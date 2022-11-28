using DNDCatalog.Core.ClassAggregate;
using DNDCatalog.Core.SpellAggregate;
using DNDCatalog.Infrastructure.Data;
using DNDCatalog.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace DNDCatalog.IntegrationTests.Data.EfRepository;
public abstract class BaseEfRepoTestFixture
{
    protected CatalogDbContext _dbContext;

    protected BaseEfRepoTestFixture()
    {
        var options = CreateNewContextOptions();
        var mockEventDispatcher = new Mock<IDomainEventDispatcher>();

        _dbContext = new CatalogDbContext(options, mockEventDispatcher.Object);
    }

    protected static DbContextOptions<CatalogDbContext> CreateNewContextOptions()
    {
        // Create a fresh service provider, and therefore a fresh
        // InMemory database instance.
        var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();

        // Create a new options instance telling the context to use an
        // InMemory database and the new service provider.
        var builder = new DbContextOptionsBuilder<CatalogDbContext>();
        builder.UseInMemoryDatabase("catalog")
               .UseInternalServiceProvider(serviceProvider);

        return builder.Options;
    }

    protected EfRepository<Spell> GetSpellRepository() => new EfRepository<Spell>(_dbContext);
    protected EfRepository<Class> GetClassRepository() => new EfRepository<Class>(_dbContext);
}
