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
using DNDCatalog.Core.MagicItemAggregate;
using DNDCatalog.IntegrationTests.Data.SpellRepository;

namespace DNDCatalog.IntegrationTests.Data.MagicItemRepository
{
    public class SearchByNameWithFilter : MagicItemRepositoryTestBase
    {
        private readonly CatalogDbContext _catalogContext;
        private readonly DNDCatalog.Infrastructure.Data.MagicItemRepository _magicItemRepository;
        private readonly Specification<MagicItem> _mockMagicItemSpecification;

        public SearchByNameWithFilter()
        {
            var mockEventDispatcher = new Mock<IDomainEventDispatcher>();
            var dbOptions = new DbContextOptionsBuilder<CatalogDbContext>()
                .UseInMemoryDatabase(databaseName: "dndcatalog")
                .Options;
            _catalogContext = new CatalogDbContext(dbOptions, mockEventDispatcher.Object);
            _magicItemRepository = new DNDCatalog.Infrastructure.Data.MagicItemRepository(_catalogContext);

            _mockMagicItemSpecification = new Mock<Specification<MagicItem>>().Object;

        }

        [Fact()]
        public async Task MatchByUkrName_ReturnsExpectedItems()
        {
            //Arrange
            const string searchText = "тест";

            MagicItem[] magicItems = DefaultMagicItems;
            _catalogContext.MagicItems.AddRange(magicItems);
            _catalogContext.SaveChanges();

            var magicItemsFiltred = magicItems.Where(x => x.NameUa.Contains(searchText)).ToList();

            //Act
            var spellsFromRepo = await _magicItemRepository.SearchByNameWithFilterAsync(_mockMagicItemSpecification, searchText);

            //Assert
            Assert.NotNull(spellsFromRepo);
            Assert.NotEmpty(spellsFromRepo);
            Assert.Equal(magicItemsFiltred.Count(), spellsFromRepo.Select(x => x.Id).Intersect(magicItemsFiltred.Select(x => x.Id)).Count());
        }

        [Fact()]
        public async Task MatchByEngName_ReturnsExpectedItems()
        {
            //Arrange
            const string searchText = "test";

            MagicItem[] magicItems = DefaultMagicItems;
            _catalogContext.MagicItems.AddRange(magicItems);
            _catalogContext.SaveChanges();

            var magicItemsFiltred = magicItems.Where(x => x.NameEng.Contains(searchText)).ToList();

            //Act
            var spellsFromRepo = await _magicItemRepository.SearchByNameWithFilterAsync(_mockMagicItemSpecification, searchText);

            //Assert
            Assert.NotNull(spellsFromRepo);
            Assert.NotEmpty(spellsFromRepo);
            Assert.Equal(magicItemsFiltred.Count(), spellsFromRepo.Select(x => x.Id).Intersect(magicItemsFiltred.Select(x => x.Id)).Count());
        }

        [Fact()]
        public async Task MachInDifferentPositions_ReturnsExpectedItems()
        {
            //Arrange
            const string searchText = "Ім'я";

            MagicItem[] magicItems = DefaultMagicItems;
            _catalogContext.MagicItems.AddRange(magicItems);
            _catalogContext.SaveChanges();

            var magicItemsFiltred = magicItems.Where(x => x.NameUa.ToLower().Contains(searchText.ToLower())).ToList();

            //Act
            var spellsFromRepo = await _magicItemRepository.SearchByNameWithFilterAsync(_mockMagicItemSpecification, searchText);

            //Assert
            Assert.NotNull(spellsFromRepo);
            Assert.NotEmpty(spellsFromRepo);
            Assert.Equal(magicItemsFiltred.Count(), spellsFromRepo.Select(x => x.Id).Intersect(magicItemsFiltred.Select(x => x.Id)).Count());
        }
    }
}