using DNDCatalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit;
using DNDCatalog.SharedKernel.Interfaces;
using Moq;
using DNDCatalog.Core.Interfaces;
using DNDCatalog.Core.ClassAggregate;

namespace DNDCatalog.IntegrationTests.Data.ClassRepository;

public class GetArchetypesByIds
{
    private readonly CatalogDbContext _catalogContext;
    private readonly DNDCatalog.Infrastructure.Data.ClassRepository _classRepository;

    public GetArchetypesByIds()
    {
        var mockEventDispatcher = new Mock<IDomainEventDispatcher>();
        var dbOptions = new DbContextOptionsBuilder<CatalogDbContext>()
            .UseInMemoryDatabase(databaseName: "dndcatalog")
            .Options;
        _catalogContext = new CatalogDbContext(dbOptions, mockEventDispatcher.Object);
        _classRepository = new DNDCatalog.Infrastructure.Data.ClassRepository(_catalogContext);
    }

    [Fact]
    public async Task GetExistingArchetypes_ReturnsExpectedArchetypes()
    {
        //Arrange
        Archetype[] archetypes = new Archetype[] 
        {
            new Archetype() {Id = Guid.NewGuid(), Name="Archetype 1"},
            new Archetype() {Id = Guid.NewGuid(), Name="Archetype 2"},
            new Archetype() {Id = Guid.NewGuid(), Name="Archetype 3"},
            new Archetype() {Id = Guid.NewGuid(), Name="Archetype 4"},
            new Archetype() {Id = Guid.NewGuid(), Name="Archetype 5"},
        };

        _catalogContext.Archetypes.AddRange(archetypes);
        _catalogContext.SaveChanges();

        List<Guid> archetypeIds = new List<Guid>() { archetypes.First().Id, archetypes.Last().Id};

        //Act
        var archetypeFromRepo = await _classRepository.GetArchetypesByIdsAsync(archetypeIds);

        //Assert
        Assert.NotNull(archetypeFromRepo);
        Assert.NotEmpty(archetypeFromRepo);
        Assert.Equal(archetypeIds.Count(), archetypeFromRepo.Select(x=>x.Id).Intersect(archetypeIds).Count());
    }
}
