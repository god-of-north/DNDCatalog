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
using DNDCatalog.IntegrationTests.Data.SpellRepository;
using DNDCatalog.Core.MagicItemAggregate;

namespace DNDCatalog.IntegrationTests.Data.MagicItemRepository
{
    public class SearchByNameWithFilterCount : MagicItemRepositoryTestBase
    {
        private readonly CatalogDbContext _catalogContext;
        private readonly Infrastructure.Data.MagicItemRepository _magicItemRepository;
        private readonly Specification<MagicItem> _mockMagicItemSpecification;

        public SearchByNameWithFilterCount()
        {
            var mockEventDispatcher = new Mock<IDomainEventDispatcher>();
            var dbOptions = new DbContextOptionsBuilder<CatalogDbContext>()
                .UseInMemoryDatabase(databaseName: "dndcatalog")
                .Options;
            _catalogContext = new CatalogDbContext(dbOptions, mockEventDispatcher.Object);
            _magicItemRepository = new Infrastructure.Data.MagicItemRepository(_catalogContext);

            _mockMagicItemSpecification = new Mock<Specification<MagicItem>>().Object;

            _catalogContext.MagicItems.RemoveRange(_catalogContext.MagicItems.ToList());
            _catalogContext.MagicItems.AddRange(DefaultMagicItems);
            _catalogContext.SaveChanges();
        }


        [Fact()]
        public async Task MatchByUkrName_ReturnsExpectedCount()
        {
            //Arrange
            const string searchText = "тест";

            MagicItem[] magicItem = DefaultMagicItems;
            var magicItemFiltred = magicItem.Where(x => x.NameUa.Contains(searchText)).ToList();

            //Act
            var magicItemsCount = await _magicItemRepository.SearchByNameWithFilterCountAsync(_mockMagicItemSpecification, searchText);

            //Assert
            Assert.Equal(magicItemFiltred.Count(), magicItemsCount);
        }

        [Fact()]
        public async Task MatchByEngName_ReturnsExpectedCount()
        {
            //Arrange
            const string searchText = "test";

            MagicItem[] magicItem = DefaultMagicItems;
            var magicItemFiltred = magicItem.Where(x => x.NameEng.Contains(searchText)).ToList();

            //Act
            var magicItemsCount = await _magicItemRepository.SearchByNameWithFilterCountAsync(_mockMagicItemSpecification, searchText);

            //Assert
            Assert.Equal(magicItemFiltred.Count(), magicItemsCount);
        }

        [Fact()]
        public async Task MachInDifferentPositions_ReturnsExpectedCount()
        {
            //Arrange
            const string searchText = "Ім'я";

            MagicItem[] magicItem = DefaultMagicItems;
            var spellsFiltred = magicItem.Where(x => x.NameUa.ToLower().Contains(searchText.ToLower())).ToList();

            //Act
            var magicItemsCount = await _magicItemRepository.SearchByNameWithFilterCountAsync(_mockMagicItemSpecification, searchText);

            //Assert
            Assert.Equal(spellsFiltred.Count(), magicItemsCount);
        }

    }
}