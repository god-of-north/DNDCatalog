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
using DNDCatalog.Core.Interfaces;
using DNDCatalog.Core.SpellAggregate;
using Ardalis.Specification;

namespace DNDCatalog.IntegrationTests.Data.SpellRepository
{
    public class SearchByNameWithFilter : SpellRepositoryTestBase
    {
        private readonly CatalogDbContext _catalogContext;
        private readonly DNDCatalog.Infrastructure.Data.SpellRepository _spellRepository;
        private readonly Specification<Spell> _mockSpellSpecification;

        public SearchByNameWithFilter()
        {
            var mockEventDispatcher = new Mock<IDomainEventDispatcher>();
            var dbOptions = new DbContextOptionsBuilder<CatalogDbContext>()
                .UseInMemoryDatabase(databaseName: "dndcatalog")
                .Options;
            _catalogContext = new CatalogDbContext(dbOptions, mockEventDispatcher.Object);
            _spellRepository = new DNDCatalog.Infrastructure.Data.SpellRepository(_catalogContext);

            _mockSpellSpecification = new Mock<Specification<Spell>>().Object;

        }


        [Fact()]
        public async Task MachByUkrName_ReturnsMachedSpells()
        {
            //Arrange
            const string searchText = "тест";
            
            Spell[] spells = DefaultSpells;
            _catalogContext.Spells.AddRange(spells);
            _catalogContext.SaveChanges();

            var spellsFiltred = spells.Where(x => x.NameUa.Contains(searchText)).ToList();

            //Act
            var spellsFromRepo = await _spellRepository.SearchByNameWithFilterAsync(_mockSpellSpecification, searchText);

            //Assert
            Assert.NotNull(spellsFromRepo);
            Assert.NotEmpty(spellsFromRepo);
            Assert.Equal(spellsFiltred.Count(), spellsFromRepo.Select(x=>x.Id).Intersect(spellsFiltred.Select(x=>x.Id)).Count());
        }

        [Fact()]
        public async Task MachByEngName_ReturnsMachedSpells()
        {
            //Arrange
            const string searchText = "test";
            
            Spell[] spells = DefaultSpells;
            _catalogContext.Spells.AddRange(spells);
            _catalogContext.SaveChanges();

            var spellsFiltred = spells.Where(x => x.NameEng.Contains(searchText)).ToList();

            //Act
            var spellsFromRepo = await _spellRepository.SearchByNameWithFilterAsync(_mockSpellSpecification, searchText);

            //Assert
            Assert.NotNull(spellsFromRepo);
            Assert.NotEmpty(spellsFromRepo);
            Assert.Equal(spellsFiltred.Count(), spellsFromRepo.Select(x=>x.Id).Intersect(spellsFiltred.Select(x=>x.Id)).Count());
        }

        [Fact()]
        public async Task MachInDifferentPositions_ReturnsMachedSpells()
        {
            //Arrange
            const string searchText = "Ім'я";
            
            Spell[] spells = DefaultSpells;
            _catalogContext.Spells.AddRange(spells);
            _catalogContext.SaveChanges();

            var spellsFiltred = spells.Where(x => x.NameUa.ToLower().Contains(searchText.ToLower())).ToList();

            //Act
            var spellsFromRepo = await _spellRepository.SearchByNameWithFilterAsync(_mockSpellSpecification, searchText);

            //Assert
            Assert.NotNull(spellsFromRepo);
            Assert.NotEmpty(spellsFromRepo);
            Assert.Equal(spellsFiltred.Count(), spellsFromRepo.Select(x=>x.Id).Intersect(spellsFiltred.Select(x=>x.Id)).Count());
        }
    }
}