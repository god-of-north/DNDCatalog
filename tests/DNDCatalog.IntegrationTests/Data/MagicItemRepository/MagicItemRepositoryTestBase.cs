using DNDCatalog.Core.MagicItemAggregate;
using DNDCatalog.Core.SpellAggregate;

namespace DNDCatalog.IntegrationTests.Data.MagicItemRepository;

public abstract class MagicItemRepositoryTestBase
{
    protected MagicItem[] DefaultMagicItems
    {
        get
        {
            MagicItem[] spells = new MagicItem[]
            {
                new MagicItem() {Id = Guid.NewGuid(), NameUa="Ім'я суффікс", NameEng="Name suffix"},
                new MagicItem() {Id = Guid.NewGuid(), NameUa="префікс ім'я", NameEng="prfix name"},
                new MagicItem() {Id = Guid.NewGuid(), NameUa="ім'я", NameEng="Name"},
                new MagicItem() {Id = Guid.NewGuid(), NameUa="ім'я дубль ім'я", NameEng="Name duplicate name"},
                new MagicItem() {Id = Guid.NewGuid(), NameUa="їїї тест1", NameEng="xxx test1"},
                new MagicItem() {Id = Guid.NewGuid(), NameUa="₴₴₴ тест2", NameEng="yyy test2"},
            };

            return spells;
        }
    }

}