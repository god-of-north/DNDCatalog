using DNDCatalog.Core.SpellAggregate;

namespace DNDCatalog.IntegrationTests.Data.SpellRepository
{
    public abstract class SpellRepositoryTestBase
    {
        protected Spell[] DefaultSpells
        {
            get
            {
                Spell[] spells = new Spell[]
                {
                new Spell() {Id = Guid.NewGuid(), NameUa="Ім'я суффікс", NameEng="Name suffix"},
                new Spell() {Id = Guid.NewGuid(), NameUa="префікс ім'я", NameEng="prfix name"},
                new Spell() {Id = Guid.NewGuid(), NameUa="ім'я", NameEng="Name"},
                new Spell() {Id = Guid.NewGuid(), NameUa="ім'я дубль ім'я", NameEng="Name duplicate name"},
                new Spell() {Id = Guid.NewGuid(), NameUa="їїї тест1", NameEng="xxx test1"},
                new Spell() {Id = Guid.NewGuid(), NameUa="₴₴₴ тест2", NameEng="yyy test2"},
                };

                return spells;
            }
        }
    }
}