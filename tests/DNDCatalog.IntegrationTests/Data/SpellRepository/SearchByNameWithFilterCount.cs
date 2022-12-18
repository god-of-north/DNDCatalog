using Xunit;
using DNDCatalog.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using DNDCatalog.Core.SpellAggregate;
using DNDCatalog.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace DNDCatalog.IntegrationTests.Data.SpellRepository
{
    public class SearchByNameWithFilterCount : SpellRepositoryTestBase
    {
        private readonly CatalogDbContext _catalogContext;
        private readonly DNDCatalog.Infrastructure.Data.SpellRepository _spellRepository;
        private readonly Specification<Spell> _mockSpellSpecification;

        public SearchByNameWithFilterCount()
        {
            var mockEventDispatcher = new Mock<IDomainEventDispatcher>();
            var dbOptions = new DbContextOptionsBuilder<CatalogDbContext>()
                .UseInMemoryDatabase(databaseName: "dndcatalog")
                .Options;
            _catalogContext = new CatalogDbContext(dbOptions, mockEventDispatcher.Object);
            _spellRepository = new DNDCatalog.Infrastructure.Data.SpellRepository(_catalogContext);

            _mockSpellSpecification = new Mock<Specification<Spell>>().Object;

            _catalogContext.Spells.RemoveRange(_catalogContext.Spells.ToList());
            _catalogContext.Spells.AddRange(DefaultSpells);
            _catalogContext.SaveChanges();
        }


        [Fact()]
        public async Task MatchByUkrName_ReturnsExpectedCount()
        {
            //Arrange
            const string searchText = "тест";

            Spell[] spells = DefaultSpells;
            var spellsFiltred = spells.Where(x => x.NameUa.Contains(searchText)).ToList();

            //Act
            var spellsCount = await _spellRepository.SearchByNameWithFilterCountAsync(_mockSpellSpecification, searchText);

            //Assert
            Assert.Equal(spellsFiltred.Count(), spellsCount);
        }

        [Fact()]
        public async Task MatchByEngName_ReturnsExpectedCount()
        {
            //Arrange
            const string searchText = "test";

            Spell[] spells = DefaultSpells;
            var spellsFiltred = spells.Where(x => x.NameEng.Contains(searchText)).ToList();

            //Act
            var spellsCount = await _spellRepository.SearchByNameWithFilterCountAsync(_mockSpellSpecification, searchText);

            //Assert
            Assert.Equal(spellsFiltred.Count(), spellsCount);
        }

        [Fact()]
        public async Task MachInDifferentPositions_ReturnsExpectedCount()
        {
            //Arrange
            const string searchText = "Ім'я";

            Spell[] spells = DefaultSpells;
            var spellsFiltred = spells.Where(x => x.NameUa.ToLower().Contains(searchText.ToLower())).ToList();

            //Act
            var spellsCount = await _spellRepository.SearchByNameWithFilterCountAsync(_mockSpellSpecification, searchText);

            //Assert
            Assert.Equal(spellsFiltred.Count(), spellsCount);
        }

    }
}