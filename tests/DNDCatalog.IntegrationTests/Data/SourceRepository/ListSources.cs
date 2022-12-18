using Xunit;
using DNDCatalog.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNDCatalog.Core.ClassAggregate;
using DNDCatalog.Core.Interfaces;
using DNDCatalog.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using DNDCatalog.Core.SpellAggregate;

namespace DNDCatalog.IntegrationTests.Data.SourceRepository
{
    public class ListSources
    {
        private readonly CatalogDbContext _catalogContext;
        private readonly DNDCatalog.Infrastructure.Data.SourceRepository _sourceRepository;
        private readonly DNDCatalog.Infrastructure.Data.SpellRepository _spellRepository;

        public ListSources()
        {
            var mockEventDispatcher = new Mock<IDomainEventDispatcher>();
            var dbOptions = new DbContextOptionsBuilder<CatalogDbContext>()
                .UseInMemoryDatabase(databaseName: "dndcatalog")
                .Options;
            _catalogContext = new CatalogDbContext(dbOptions, mockEventDispatcher.Object);
            _sourceRepository = new DNDCatalog.Infrastructure.Data.SourceRepository(_catalogContext);
            _spellRepository = new DNDCatalog.Infrastructure.Data.SpellRepository(_catalogContext);
        }


        [Fact()]
        public async Task GetSources_ReturnsAllSources()
        {
            //Arrange
            Spell[] spells = new Spell[]
            {
                new Spell() {Id = Guid.NewGuid(), Source="Source 1"},
                new Spell() {Id = Guid.NewGuid(), Source="Source 2"},
                new Spell() {Id = Guid.NewGuid(), Source="Source 1"},
                new Spell() {Id = Guid.NewGuid(), Source="Source 3"},
                new Spell() {Id = Guid.NewGuid(), Source="Source 2"},
                new Spell() {Id = Guid.NewGuid(), Source="Source 1"},
            };

            _catalogContext.Spells.AddRange(spells);
            _catalogContext.SaveChanges();

            List<string> sources = spells.Select(x => x.Source!).Distinct().ToList();

            //Act
            var sourcesFromRepo = await _sourceRepository.ListSourcesAsync();

            //Assert
            Assert.NotNull(sourcesFromRepo);
            Assert.NotEmpty(sourcesFromRepo);
            Assert.Equal(sources.Count(), sourcesFromRepo.Count());
        }
    }
}