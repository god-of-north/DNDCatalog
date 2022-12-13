using System.Text.Json;
using DNDCatalog.Core.ClassAggregate;
using DNDCatalog.Core.MagicItemAggregate;
using DNDCatalog.Core.SpellAggregate;
using DNDCatalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DNDCatalog.Web;
public static class SeedData
{

    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var dbContext = new CatalogDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<CatalogDbContext>>(), null))
        {
            if (dbContext.Spells.Any() || dbContext.Classes.Any() || dbContext.Archetypes.Any())
            {
            }
            else 
            {
                PopulateClasses(dbContext);
                PopulateArchetypes(dbContext);
                PopulateSpells(dbContext);
            }

            if (!dbContext.MagicItems.Any())
                PopulateMagicItems(dbContext);


        }
    }

    public static T LoadJson<T>(string file)
    {
        using (StreamReader r = new StreamReader(file))
        {
            string json = r.ReadToEnd();

            T t = JsonSerializer.Deserialize<T>(json)!;
            return t;
        }
    }

    private static IEnumerable<Spell> LoadSpells()
    {
        return Directory.EnumerateFiles(@"D:\Work\GON\dnd\prepared\spells\", "*.json")
            .Select(f => LoadJson<Spell>(f));
    }

    private static IEnumerable<Class> LoadClasses()
    {
        return Directory.EnumerateFiles(@"D:\Work\GON\dnd\prepared\classes\", "*.json")
            .Select(f => LoadJson<Class>(f));
    }

    private static IEnumerable<Archetype> LoadArchetypes()
    {
        return Directory.EnumerateFiles(@"D:\Work\GON\dnd\prepared\archetypes\", "*.json")
            .Select(f => LoadJson<Archetype>(f));
    }

    private static IEnumerable<MagicItem> LoadMagicItems()
    {
        return Directory.EnumerateFiles(@"D:\Work\GON\dnd\prepared\magic_items", "*.json")
            .Select(f => LoadJson<MagicItem>(f));
    }

    public static void PopulateTestData(CatalogDbContext dbContext)
    {
        PopulateMagicItems(dbContext);
    }

    private static void PopulateSpells(CatalogDbContext dbContext)
    {
        var spells = LoadSpells();
        foreach (var spell in spells)
        {
            spell.Classes = dbContext.Classes.Where(c => spell.Classes!.Select(x => x.Id).Contains(c.Id))?.ToList();
            if (!(spell.Archetypes == null || spell.Archetypes.Count() == 0))
                spell.Archetypes = dbContext.Archetypes.Where(a => spell.Archetypes!.Select(x => x.Id).Contains(a.Id))?.ToList();
            dbContext.Spells.Add(spell);
        }
        dbContext.SaveChanges();
    }

    private static void PopulateArchetypes(CatalogDbContext dbContext)
    {
        var archetypes = LoadArchetypes();
        foreach (var archetype in archetypes)
        {
            archetype.Class = dbContext.Classes.First(c => c.Id == archetype.Class.Id);
            dbContext.Archetypes.Add(archetype);
        }
        dbContext.SaveChanges();
    }

    private static void PopulateClasses(CatalogDbContext dbContext)
    {
        var classes = LoadClasses().ToList();
        dbContext.Classes.AddRange(classes);
        dbContext.SaveChanges();
    }

    private static void PopulateMagicItems(CatalogDbContext dbContext)
    {
        var items = LoadMagicItems().ToList();
        dbContext.MagicItems.AddRange(items);
        dbContext.SaveChanges();
    }




}
