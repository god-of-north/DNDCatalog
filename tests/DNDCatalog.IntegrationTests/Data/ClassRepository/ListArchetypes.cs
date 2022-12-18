using Xunit;
using DNDCatalog.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNDCatalog.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using DNDCatalog.Core.ClassAggregate;

namespace DNDCatalog.IntegrationTests.Data.ClassRepository
{
    public class ListArchetypes
    {
        private readonly CatalogDbContext _catalogContext;
        private readonly DNDCatalog.Infrastructure.Data.ClassRepository _classRepository;

        public ListArchetypes()
        {
            var mockEventDispatcher = new Mock<IDomainEventDispatcher>();
            var dbOptions = new DbContextOptionsBuilder<CatalogDbContext>()
                .UseInMemoryDatabase(databaseName: "dndcatalog")
                .Options;
            _catalogContext = new CatalogDbContext(dbOptions, mockEventDispatcher.Object);
            _classRepository = new DNDCatalog.Infrastructure.Data.ClassRepository(_catalogContext);
        }

        [Fact()]
        public async Task GetArchetypes_ReturnsAllArchetypes()
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

            List<Guid> archetypeIds = archetypes.Select(x => x.Id).ToList();

            //Act
            var archetypeFromRepo = await _classRepository.ListArchetypesAsync();

            //Assert
            Assert.NotNull(archetypeFromRepo);
            Assert.NotEmpty(archetypeFromRepo);
            Assert.Equal(archetypes.Count(), archetypeFromRepo.Select(x => x.Id).Intersect(archetypeIds).Count());
        }
    }
}