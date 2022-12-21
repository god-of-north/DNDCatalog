using DNDCatalog.Core.ClassAggregate;
using DNDCatalog.Core.MagicItemAggregate;
using DNDCatalog.Core.SpellAggregate;
using DNDCatalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNDCatalog.FunctionalTests;

public static class FakeData
{
    public static Spell spellFireball { get; } = new Spell() { Id = Guid.Parse("2b04a7bb-fdde-46b1-b52d-517ed9c2caa0"), NameEng = "Fireball", Source = "Книга гравця" };
    public static Spell spellDetectMagic { get; } = new Spell() { Id = Guid.Parse("2e3ede8c-2a5f-4acc-9231-b758c2e04dbe"), NameEng = "Detect magic", Source = "Basic rules" };
    public static Spell spellMagicWeapon { get; } = new Spell() { Id = Guid.Parse("3be36ba9-6b7c-40f6-9f85-77d62fc8781d"), NameEng = "Magic weapon", Source = "Книга гравця" };

    public static IEnumerable<Spell> DefaultSpells
    {
        get
        {
            yield return spellFireball;
            yield return spellDetectMagic;
            yield return spellMagicWeapon;
        }
    }

    public static Class classCleric { get; } = new Class(){Id = Guid.Parse("3d9160f1-238a-4801-a62f-3330ca47c6bd"), Name = "Cleric",Description = ""};
    public static Class classWarlock { get; } = new Class(){Id = Guid.Parse("5dbe7987-589c-428d-aaaa-9df776aa1488"), Name = "Warlock",Description = ""};
    public static Class classBard { get; } = new Class(){ Id = Guid.Parse("430ffa07-bfa6-4df0-bac8-162ef8604c89"), Name = "Bard",Description = ""};
    public static Class classArtificer { get; } = new Class(){ Id = Guid.Parse("435b3426-58be-4115-b86c-e9eeeec0b853"), Name = "Artificer",Description = ""};
    public static Class classWizard { get; } = new Class(){ Id = Guid.Parse("15008163-303c-452b-9022-577ac8afa70a"), Name = "Wizard",Description = ""};
    public static Class classMonk { get; } = new Class(){ Id = Guid.Parse("a0c83a95-32e4-4b42-9a6b-91f61f75812a"), Name = "Monk",Description = ""};
    public static Class classRogue { get; } = new Class(){ Id = Guid.Parse("a54c223b-92c7-48ea-a601-e91ade6cffc5"), Name = "Rogue",Description = ""};
    public static Class classDruid { get; } = new Class(){ Id = Guid.Parse("ac78f523-3134-4d72-bbeb-80237d9550fc"), Name = "Druid",Description = ""};
    public static Class classSorcerer { get; } = new Class(){ Id = Guid.Parse("be376627-acb5-4c77-a344-5ee391408692"), Name = "Sorcerer",Description = ""};
    public static Class classRanger { get; } = new Class(){ Id = Guid.Parse("cfdc715c-d181-4f55-aa43-f8a969d086e0"), Name = "Ranger",Description = ""};
    public static Class classPaladin { get; } = new Class() { Id = Guid.Parse("f8b63b17-3701-4f8a-8b19-e7f0001528c1"), Name = "Paladin", Description = "" };

    public static IEnumerable<Class> DefaultClasses
    {
        get
        {
            yield return classCleric;
            yield return classWarlock ;
            yield return classBard ;
            yield return classArtificer ;
            yield return classWizard ;
            yield return classMonk ;
            yield return classRogue ;
            yield return classDruid ;
            yield return classSorcerer ;
            yield return classRanger ;
            yield return classPaladin ;
        }
    }

    

    public static Archetype archetype1 { get; } = new Archetype() { Id = Guid.Parse("00e2adde-c125-443a-b735-fb3c8c0d528a"), Name = "клятва смотрителей" };
    public static Archetype archetype2 { get; } = new Archetype() { Id = Guid.Parse("0e682789-75d7-4b1c-82c5-fd508f9f312a"), Name = "артиллерист"};
    public static Archetype archetype3 { get; } = new Archetype() { Id = Guid.Parse("28078c51-ef06-4646-9764-0b8c65bc274a"), Name = "домен кузни"};
    public static Archetype archetype4 { get; } = new Archetype() { Id = Guid.Parse("2ab36b7c-68e7-4bac-8b2d-69bf4bfdbd47"), Name = "домен магии"};
    public static Archetype archetype5 { get; } = new Archetype() { Id = Guid.Parse("442fa605-7468-48cf-8ee0-8a4b3a7b49f9"), Name = "клятва славы"};
    public static Archetype archetype6 { get; } = new Archetype() { Id = Guid.Parse("91faae74-cf26-4210-8b7b-cdf3aa1b7a04"), Name = "домен войны"};
    public static Archetype archetype7 { get; } = new Archetype() { Id = Guid.Parse("d1451e8a-03f4-4159-b4b8-ec05e48d633e"), Name = "домен света"};
    public static Archetype archetype8 { get; } = new Archetype() { Id = Guid.Parse("d84df18c-ba68-4ed9-a871-b0c6c52a54d8"), Name = "исчадие"};
    public static Archetype archetype9 { get; } = new Archetype() { Id = Guid.Parse("e37aa9ae-60df-44a0-9209-c13f8af12ace"), Name = "путь четырёх стихий"};

    public static IEnumerable<Archetype> DefaultArchetypes
    {
        get
        {
            yield return archetype1;
            yield return archetype2;
            yield return archetype3;
            yield return archetype4;
            yield return archetype5;
            yield return archetype6;
            yield return archetype7;
            yield return archetype8;
            yield return archetype9;
        }
    }

    public static IEnumerable<(Spell, Class)> SpellClasses
    {
        get 
        {
            yield return (spellFireball, classArtificer);
            yield return (spellFireball, classWarlock);
            yield return (spellFireball, classWizard);
            yield return (spellFireball, classSorcerer);
            yield return (spellFireball, classCleric);
            yield return (spellFireball, classMonk);
            yield return (spellDetectMagic, classBard);
            yield return (spellDetectMagic, classWizard);
            yield return (spellDetectMagic, classDruid);
            yield return (spellDetectMagic, classCleric);
            yield return (spellDetectMagic, classArtificer);
            yield return (spellDetectMagic, classPaladin);
            yield return (spellDetectMagic, classRanger);
            yield return (spellDetectMagic, classWarlock);
            yield return (spellMagicWeapon, classWarlock);
            yield return (spellMagicWeapon, classWizard);
            yield return (spellMagicWeapon, classArtificer);
            yield return (spellMagicWeapon, classPaladin);
            yield return (spellMagicWeapon, classRanger);
            yield return (spellMagicWeapon, classCleric);
        }
    }

    public static IEnumerable<(Spell, Archetype)> SpellArchetypes
    {
        get
        {
            yield return (spellFireball, archetype2);
            yield return (spellFireball, archetype7);
            yield return (spellFireball, archetype8);
            yield return (spellFireball, archetype9);
            yield return (spellDetectMagic, archetype1);
            yield return (spellDetectMagic, archetype4);
            yield return (spellMagicWeapon, archetype3);
            yield return (spellMagicWeapon, archetype4);
            yield return (spellMagicWeapon, archetype5);
            yield return (spellMagicWeapon, archetype6);
        }
    }

    public static IEnumerable<(Class, Archetype)> ClassArchetypes
    {
        get
        {
            yield return (classPaladin, archetype1);
            yield return (classPaladin, archetype5);
            yield return (classArtificer, archetype2);
            yield return (classCleric, archetype3);
            yield return (classCleric, archetype4);
            yield return (classCleric, archetype6);
            yield return (classCleric, archetype7);
            yield return (classSorcerer, archetype8);
            yield return (classMonk, archetype9);
        }
    }


    public static MagicItem magicItemAdamantineArmor { get; } = new MagicItem()
    {
        Id = Guid.Parse("B4E23081-1C55-4875-ADF0-BDC4075419D6"),
        NameUa = "",
        DescriptionUa = "",
        Consumable = false,
        Charged = false,
        NameRus = "Адамантиновый доспех",
        NameEng = "Adamantine Armor",
        DescriptionUa1 = "",
        DescriptionUa2 = "",
        DescriptionRus1 = "",
        DescriptionRus2 = "",
        Source = "«Dungeon master's guide»",
        Attunement = false,
        Type = MagicItemType.Armour,
        Rarity = Rarity.Uncommon,
        Price = new RecomendedPrice()
        {
            Formula = "(1d6 + 1) * 100",
            MinPrice = 101,
            MaxPrice = 500
        }
    };
    public static MagicItem magicItemAlchemyJugBlue { get; } = new MagicItem()
    {
        Id = Guid.Parse("E41583C9-C49A-4A6E-B875-9D046695F6F8"),
        NameUa = "",
        DescriptionUa = "",
        Consumable = false,
        Charged = false,
        NameRus = "Алхимический сосуд (синий)",
        NameEng = "Alchemy Jug (Blue)",
        DescriptionUa1 = "",
        DescriptionUa2 = "",
        DescriptionRus1 = "",
        DescriptionRus2 = "",
        Source = "«Candlekeep Mysteries»",
        Attunement = false,
        Type = MagicItemType.WondrousItem,
        Rarity = Rarity.Uncommon,
        Price = new RecomendedPrice()
        {
            Formula = "(1d6 + 1) * 100",
            MinPrice = 101,
            MaxPrice = 500
        }
    };
    public static MagicItem magicItemAmmunitionPlus1 { get; } = new MagicItem()
    {
        Id = Guid.Parse("2085ACAC-E31F-4B79-8697-A1B11082E153"),
        NameUa = "",
        DescriptionUa = "",
        Consumable = true,
        Charged = false,
        NameRus = "Боеприпасы +1",
        NameEng = "Ammunition +1",
        DescriptionUa1 = "",
        DescriptionRus1 = "",
        Source = "Руководство мастера",
        Attunement = false,
        Type = MagicItemType.Ammunition,
        Rarity = Rarity.Uncommon,
        MagicBonus = 1,
        Price = new RecomendedPrice()
        {
            Formula = "((1d6 + 1) * 100) / 2",
            MinPrice = 51,
            MaxPrice = 250
        }
    };
    public static MagicItem magicItemArmorPlus3 { get; } = new MagicItem()
    {
        Id = Guid.Parse("734186A0-38CD-4393-967B-A8A13A09D819"),
        NameUa = "",
        DescriptionUa = "",
        Consumable = false,
        Charged = false,
        NameRus = "Доспех +3",
        NameEng = "Armor +3",
        DescriptionUa1 = "",
        DescriptionRus1 = "",
        Source = "Руководство мастера",
        Attunement = false,
        Type = MagicItemType.Armour,
        Rarity = Rarity.Legendary,
        MagicBonus = 3,
        Price = new RecomendedPrice()
        {
            Formula = "2d6 * 25000",
            MinPrice = 50001,
            MaxPrice = 250000
        }
    };
    public static MagicItem magicItemBootsOftheWinterlands { get; } = new MagicItem()
    {
        Id = Guid.Parse("A66627B1-0634-45AB-BBE0-1D2E7118B6CF"),
        NameUa = "",
        DescriptionUa = "",
        Consumable = false,
        Charged = false,
        NameRus = "Заполярные сапоги",
        NameEng = "Boots of the Winterlands",
        DescriptionUa1 = "",
        DescriptionUa2 = "",
        DescriptionRus1 = "",
        DescriptionRus2 = "",
        Source = "«Dungeon master's guide»",
        Attunement = true,
        Type = MagicItemType.WondrousItem,
        Rarity = Rarity.Uncommon,
        Price = new RecomendedPrice()
        {
            Formula = "(1d6 + 1) * 100",
            MinPrice = 101,
            MaxPrice = 500
        }
    };
    public static MagicItem magicItemCloakOfInvisibility { get; } = new MagicItem()
    {
        Id = Guid.Parse("47C105E2-44FD-4E28-B0B1-C188F64DC66E"),
        NameUa = "",
        DescriptionUa = "",
        Consumable = false,
        Charged = false,
        NameRus = "Плащ невидимости",
        NameEng = "Cloak of Invisibility",
        DescriptionUa1 = "",
        DescriptionUa2 = "",
        DescriptionRus1 = "",
        DescriptionRus2 = "",
        Source = "«Dungeon master's guide»",
        Attunement = true,
        Type = MagicItemType.WondrousItem,
        Rarity = Rarity.Legendary,
        Price = new RecomendedPrice()
        {
            Formula = "2d6 * 25000",
            MinPrice = 50001,
            MaxPrice = 250000
        }
    };
    public static MagicItem magicItemDwarvenPlate { get; } = new MagicItem()
    {
        Id = Guid.Parse("2ED1DB0D-7CA8-412B-BE42-88F52B706C5B"),
        NameUa = "",
        DescriptionUa = "",
        Consumable = false,
        Charged = false,
        NameRus = "Латы дварфов",
        NameEng = "Dwarven Plate",
        DescriptionUa1 = "",
        DescriptionUa2 = "",
        DescriptionRus1 = "",
        DescriptionRus2 = "",
        Source = "«Dungeon master's guide»",
        Attunement = false,
        Type = MagicItemType.Armour,
        Rarity = Rarity.VeryRare,
        Price = new RecomendedPrice()
        {
            Formula = "(1d4 + 1) * 10000",
            MinPrice = 5001,
            MaxPrice = 50000
        }
    };
    public static MagicItem magicItemGemOfSeeing { get; } = new MagicItem()
    {
        Id = Guid.Parse("881CFDCB-BA9E-431A-B1D3-A3D5563D2505"),
        NameUa = "",
        DescriptionUa = "",
        Consumable = false,
        Charged = true,
        NameRus = "Камень зрения",
        NameEng = "Gem of Seeing",
        DescriptionUa1 = "",
        DescriptionUa2 = "",
        DescriptionRus1 = "",
        DescriptionRus2 = "",
        Source = "«Dungeon master's guide»",
        Attunement = true,
        Type = MagicItemType.WondrousItem,
        Rarity = Rarity.Rare,
        Price = new RecomendedPrice()
        {
            Formula = "2d10 * 1000",
            MinPrice = 501,
            MaxPrice = 5000
        }
    };
    public static MagicItem magicItemHelmOfTelepathy { get; } = new MagicItem()
    {
        Id = Guid.Parse("042E0460-B6D8-45E2-A9C4-273265DF2AEB"),
        NameUa = "",
        DescriptionUa = "",
        Consumable = false,
        Charged = false,
        NameRus = "Шлем телепатии",
        NameEng = "Helm of Telepathy",
        DescriptionUa1 = "",
        DescriptionUa2 = "",
        DescriptionRus1 = "",
        DescriptionRus2 = "",
        Source = "«Dungeon master's guide»",
        Attunement = true,
        Type = MagicItemType.WondrousItem,
        Rarity = Rarity.Uncommon,
        Price = new RecomendedPrice()
        {
            Formula = "(1d6 + 1) * 100",
            MinPrice = 101,
            MaxPrice = 500
        }
    };
    public static MagicItem magicItemMaceOfSmiting { get; } = new MagicItem()
    {
        Id = Guid.Parse("A0DE6BC3-02D8-4485-A3DC-C8BDD9320B44"),
        NameUa = "",
        DescriptionUa = "",
        Consumable = false,
        Charged = false,
        NameRus = "Булава кары",
        NameEng = "Mace of Smiting",
        DescriptionUa1 = "",
        DescriptionUa2 = "",
        DescriptionRus1 = "",
        DescriptionRus2 = "",
        Source = "«Dungeon master's guide»",
        Attunement = false,
        Type = MagicItemType.MeleeWeapon,
        Rarity = Rarity.Rare,
        Price = new RecomendedPrice()
        {
            Formula = "2d10 * 1000",
            MinPrice = 501,
            MaxPrice = 5000
        }
    };
    public static MagicItem magicItemMaceOfTerror { get; } = new MagicItem()
    {
        Id = Guid.Parse("B218146B-656C-4ABD-A667-428758ECBEAA"),
        NameUa = "",
        DescriptionUa = "",
        Consumable = false,
        Charged = true,
        NameRus = "Булава ужаса",
        NameEng = "Mace of Terror",
        DescriptionUa1 = "",
        DescriptionUa2 = "",
        DescriptionRus1 = "",
        DescriptionRus2 = "",
        Source = "«Dungeon master's guide»",
        Attunement = true,
        Type = MagicItemType.MeleeWeapon,
        Rarity = Rarity.Rare,
        Price = new RecomendedPrice()
        {
            Formula = "2d10 * 1000",
            MinPrice = 501,
            MaxPrice = 5000
        }
    };
    public static MagicItem magicItemOathbow { get; } = new MagicItem()
    {
        Id = Guid.Parse("2D2DFC7D-D74A-4539-A8CA-85602DDFCC7F"),
        NameUa = "",
        DescriptionUa = "",
        Consumable = false,
        Charged = false,
        NameRus = "Лук клятвы",
        NameEng = "Oathbow",
        DescriptionUa1 = "",
        DescriptionUa2 = "",
        DescriptionRus1 = "",
        DescriptionRus2 = "",
        Source = "«Dungeon master's guide»",
        Attunement = true,
        Type = MagicItemType.RangedWeapon,
        Rarity = Rarity.VeryRare,
        Price = new RecomendedPrice()
        {
            Formula = "(1d4 + 1) * 10000",
            MinPrice = 5001,
            MaxPrice = 50000
        }
    };
    public static MagicItem magicItemPotionOfClimbing { get; } = new MagicItem()
    {
        Id = Guid.Parse("321E61A0-6A4A-4565-B48E-657B0B8B2353"),
        NameUa = "",
        DescriptionUa = "",
        Consumable = true,
        Charged = false,
        NameRus = "Зелье лазания",
        NameEng = "Potion of Climbing",
        DescriptionUa1 = "",
        DescriptionUa2 = "",
        DescriptionRus1 = "",
        DescriptionRus2 = "",
        Source = "«Dungeon master's guide»",
        Attunement = false,
        Type = MagicItemType.Potion,
        Rarity = Rarity.Common,
        Price = new RecomendedPrice()
        {
            Formula = "((1d6 + 1) * 10) / 2",
            MinPrice = 25,
            MaxPrice = 50
        }
    };
    public static MagicItem magicItemPotionOfFireBreath { get; } = new MagicItem()
    {
        Id = Guid.Parse("7D80141C-F3C9-4B80-AF12-BA1783B99DB1"),
        NameUa = "",
        DescriptionUa = "",
        Consumable = true,
        Charged = false,
        NameRus = "Зелье огненного дыхания",
        NameEng = "Potion of Fire Breath",
        DescriptionUa1 = "",
        DescriptionUa2 = "",
        DescriptionRus1 = "",
        DescriptionRus2 = "",
        Source = "«Dungeon master's guide»",
        Attunement = false,
        Type = MagicItemType.Potion,
        Rarity = Rarity.Uncommon,
        Price = new RecomendedPrice()
        {
            Formula = "((1d6 + 1) * 100) / 2",
            MinPrice = 51,
            MaxPrice = 250
        }
    };
    public static MagicItem magicItemPotionOfGaseousForm { get; } = new MagicItem()
    {
        Id = Guid.Parse("5974B2EB-473C-40F3-856E-A1378BB36503"),
        NameUa = "",
        DescriptionUa = "",
        Consumable = true,
        Charged = false,
        NameRus = "Зелье газообразной формы",
        NameEng = "Potion of Gaseous Form",
        DescriptionUa1 = "",
        DescriptionUa2 = "",
        DescriptionRus1 = "",
        DescriptionRus2 = "",
        Source = "«Dungeon master's guide»",
        Attunement = false,
        Type = MagicItemType.Potion,
        Rarity = Rarity.Rare,
        Price = new RecomendedPrice()
        {
            Formula = "(2d10 * 1000) / 2",
            MinPrice = 251,
            MaxPrice = 2500
        }
    };
    public static MagicItem magicItemPotionOfHealing { get; } = new MagicItem()
    {
        Id = Guid.Parse("E7E5F1E6-D511-471F-8350-0D89CE82E943"),
        NameUa = "",
        DescriptionUa = "",
        Consumable = true,
        Charged = false,
        NameRus = "Зелье лечения",
        NameEng = "Potion of Healing",
        DescriptionUa1 = "",
        DescriptionUa2 = "",
        DescriptionRus1 = "",
        DescriptionRus2 = "",
        Source = "«Dungeon master's guide»",
        Attunement = false,
        Type = MagicItemType.Potion,
        Rarity = Rarity.Common,
        Price = new RecomendedPrice()
        {
            Formula = "((1d6 + 1) * 10) / 2",
            MinPrice = 25,
            MaxPrice = 50
        }
    };
    public static MagicItem magicItemRingOfProtection { get; } = new MagicItem()
    {
        Id = Guid.Parse("280AFC85-4947-4F7B-A39D-FD501A27BA9E"),
        NameUa = "",
        DescriptionUa = "",
        Consumable = false,
        Charged = false,
        NameRus = "Кольцо защиты",
        NameEng = "Ring of Protection",
        DescriptionUa1 = "",
        DescriptionUa2 = "",
        DescriptionRus1 = "",
        DescriptionRus2 = "",
        Source = "«Dungeon master's guide»",
        Attunement = true,
        Type = MagicItemType.Ring,
        Rarity = Rarity.Rare,
        Price = new RecomendedPrice()
        {
            Formula = "2d10 * 1000",
            MinPrice = 501,
            MaxPrice = 5000
        }
    };
    public static MagicItem magicItemRingOfWarmth { get; } = new MagicItem()
    {
        Id = Guid.Parse("C10AFF7C-E460-4CAD-A6E0-12316991C89A"),
        NameUa = "",
        DescriptionUa = "",
        Consumable = false,
        Charged = false,
        NameRus = "Кольцо тепла",
        NameEng = "Ring of Warmth",
        DescriptionUa1 = "",
        DescriptionUa2 = "",
        DescriptionRus1 = "",
        DescriptionRus2 = "",
        Source = "«Dungeon master's guide»",
        Attunement = true,
        Type = MagicItemType.Ring,
        Rarity = Rarity.Uncommon,
        Price = new RecomendedPrice()
        {
            Formula = "(1d6 + 1) * 100",
            MinPrice = 101,
            MaxPrice = 500
        }
    };
    public static MagicItem magicItemRodOfRulership { get; } = new MagicItem()
    {
        Id = Guid.Parse("09C76D01-43F5-4655-BE16-EC5453E53AD8"),
        NameUa = "",
        DescriptionUa = "",
        Consumable = false,
        Charged = false,
        NameRus = "Жезл правления",
        NameEng = "Rod of Rulership",
        DescriptionUa1 = "",
        DescriptionUa2 = "",
        DescriptionRus1 = "",
        DescriptionRus2 = "",
        Source = "«Dungeon master's guide»",
        Attunement = true,
        Type = MagicItemType.Rod,
        Rarity = Rarity.Rare,
        Price = new RecomendedPrice()
        {
            Formula = "2d10 * 1000",
            MinPrice = 501,
            MaxPrice = 5000
        }
    };
    public static MagicItem magicItemSentinelShield { get; } = new MagicItem()
    {
        Id = Guid.Parse("A538FBFA-0A9C-402A-8B3D-08EBEF90A457"),
        NameUa = "",
        DescriptionUa = "",
        Consumable = false,
        Charged = false,
        NameRus = "Щит часового",
        NameEng = "Sentinel Shield",
        DescriptionUa1 = "",
        DescriptionUa2 = "",
        DescriptionRus1 = "",
        DescriptionRus2 = "",
        Source = "«Dungeon master's guide»",
        Attunement = true,
        Type = MagicItemType.Shield,
        Rarity = Rarity.Uncommon,
        Price = new RecomendedPrice()
        {
            Formula = "(1d6 + 1) * 100",
            MinPrice = 101,
            MaxPrice = 500
        }
    };
    public static MagicItem magicItemSpellScroll5thLevel { get; } = new MagicItem()
    {
        Id = Guid.Parse("EDB1C8CF-7DC5-40AA-B678-D887B5F91960"),
        NameUa = "",
        DescriptionUa = "",
        Consumable = false,
        Charged = false,
        NameRus = "Свиток заклинания (5 уровень)",
        NameEng = "Spell Scroll (5th level)",
        DescriptionUa1 = "",
        DescriptionRus1 = "",
        Source = "Руководство мастера",
        Attunement = false,
        Type = MagicItemType.Scroll,
        Rarity = Rarity.Rare,
        Price = new RecomendedPrice()
        {
            Formula = "2d10 * 1000",
            MinPrice = 501,
            MaxPrice = 5000
        }
    };
    public static MagicItem magicItemStaffOfThePython { get; } = new MagicItem()
    {
        Id = Guid.Parse("94415A99-880A-4B5E-9030-21F1E0EE5FEB"),
        NameUa = "",
        DescriptionUa = "",
        Consumable = false,
        Charged = false,
        NameRus = "Посох питона",
        NameEng = "Staff of the Python",
        DescriptionUa1 = "",
        DescriptionUa2 = "",
        DescriptionRus1 = "",
        DescriptionRus2 = "",
        Source = "«Dungeon master's guide»",
        Attunement = true,
        Type = MagicItemType.Staff,
        Rarity = Rarity.Uncommon,
        Price = new RecomendedPrice()
        {
            Formula = "(1d6 + 1) * 100",
            MinPrice = 101,
            MaxPrice = 500
        }
    };
    public static MagicItem magicItemViciousWeapon { get; } = new MagicItem()
    {
        Id = Guid.Parse("CE5F1FDD-AC9C-49A2-9539-65F76F1FE7D6"),
        NameUa = "",
        DescriptionUa = "",
        Consumable = false,
        Charged = false,
        NameRus = "Жестокое оружие",
        NameEng = "Vicious Weapon",
        DescriptionUa1 = "",
        DescriptionUa2 = "",
        DescriptionRus1 = "",
        DescriptionRus2 = "",
        Source = "«Dungeon master's guide»",
        Attunement = false,
        Type = MagicItemType.Weapon,
        Rarity = Rarity.Rare,
        Price = new RecomendedPrice()
        {
            Formula = "2d10 * 1000",
            MinPrice = 501,
            MaxPrice = 5000
        }
    };
    public static MagicItem magicItemIounStone { get; } = new MagicItem()
    {
        Id = Guid.Parse("C3393876-FE02-428A-9FED-E14ADB9D8F95"),
        NameUa = "",
        DescriptionUa = "",
        Consumable = false,
        Charged = false,
        NameRus = "Камень Йоун",
        NameEng = "Ioun Stone",
        DescriptionUa1 = "",
        DescriptionRus1 = "",
        DescriptionRus2 = "",
        Attunement = false,
        Type = MagicItemType.WondrousItem,
        Rarity = Rarity.Varies
    };
    public static MagicItem magicItemHagEye { get; } = new MagicItem()
    {
        Id = Guid.Parse("B333A401-FD08-46B1-82DD-8C759E5D711D"),
        NameUa = "",
        DescriptionUa = "",
        Consumable = false,
        Charged = false,
        NameRus = "Глаз карги",
        NameEng = "Hag Eye",
        DescriptionUa1 = "",
        DescriptionRus1 = "",
        Source = "Бестиарий",
        Attunement = false,
        Type = MagicItemType.WondrousItem,
        Rarity = Rarity.UnknownRarity
    };
    public static MagicItem magicItemBookOfVileDarkness { get; } = new MagicItem()
    {
        Id = Guid.Parse("A9E8300B-38B5-4103-819A-24E93B78F5AE"),
        NameUa = "",
        DescriptionUa = "",
        Consumable = false,
        Charged = false,
        NameRus = "Книга мерзкой тьмы",
        NameEng = "Book of Vile Darkness",
        DescriptionRus1 = "",
        DescriptionRus2 = "",
        Source = "«Dungeon master's guide»",
        Attunement = false,
        Type = MagicItemType.WondrousItem,
        Rarity = Rarity.Artifact,
        Price = new RecomendedPrice()
        {
            Notes = "невозможно купить",
            MinPrice = 250001
        }
    };
    public static MagicItem magicItemWandOfSecrets { get; } = new MagicItem()
    {
        Id = Guid.Parse("99757A03-3059-487B-BB47-29DFB72F1820"),
        NameUa = "",
        DescriptionUa = "",
        Consumable = false,
        Charged = false,
        NameRus = "Волшебная палочка секретов",
        NameEng = "Wand of Secrets",
        DescriptionUa1 = "",
        DescriptionUa2 = "",
        DescriptionRus1 = "",
        DescriptionRus2 = "",
        Source = "«Dungeon master's guide»",
        Attunement = false,
        Type = MagicItemType.Wand,
        Rarity = Rarity.Uncommon,
        Price = new RecomendedPrice()
        {
            Formula = "(1d6 + 1) * 100",
            MinPrice = 101,
            MaxPrice = 500
        }
    };

    public static IEnumerable<MagicItem> DefaultMagicItems
    {
        get
        { 
            yield return magicItemAdamantineArmor;
            yield return magicItemAlchemyJugBlue;
            yield return magicItemAmmunitionPlus1;
            yield return magicItemArmorPlus3;
            yield return magicItemBootsOftheWinterlands;
            yield return magicItemCloakOfInvisibility;
            yield return magicItemDwarvenPlate;
            yield return magicItemGemOfSeeing;
            yield return magicItemHelmOfTelepathy;
            yield return magicItemMaceOfSmiting;
            yield return magicItemMaceOfTerror;
            yield return magicItemOathbow;
            yield return magicItemPotionOfClimbing;
            yield return magicItemPotionOfFireBreath;
            yield return magicItemPotionOfGaseousForm;
            yield return magicItemPotionOfHealing;
            yield return magicItemRingOfProtection;
            yield return magicItemRingOfWarmth;
            yield return magicItemRodOfRulership;
            yield return magicItemSentinelShield;
            yield return magicItemSpellScroll5thLevel;
            yield return magicItemStaffOfThePython;
            yield return magicItemViciousWeapon;
            yield return magicItemIounStone;
            yield return magicItemHagEye;
            yield return magicItemBookOfVileDarkness;
            yield return magicItemWandOfSecrets;
        }
    }



    public static void PopulateData(CatalogDbContext db)
    {
        db.Classes.AddRange(DefaultClasses);
        db.SaveChanges();

        foreach (var archetype in DefaultArchetypes)
        {
            var archetypeClassId = ClassArchetypes.Where(x => x.Item2.Id == archetype.Id).Select(x => x.Item1.Id).Single();
            archetype.Class = db.Classes.Where(c => archetypeClassId == c.Id).Single();
            db.Archetypes.Add(archetype);
        }
        db.SaveChanges();

        foreach (var spell in DefaultSpells)
        {
            var spellClassesIds = SpellClasses.Where(x => x.Item1.Id == spell.Id).Select(x => x.Item2.Id).ToList();
            spell.Classes = db.Classes.Where(c => spellClassesIds.Contains(c.Id)).ToList();

            var spellArchetypesIds = SpellArchetypes.Where(x => x.Item1.Id == spell.Id).Select(x => x.Item2.Id).ToList();
            spell.Archetypes = db.Archetypes.Where(a => spellArchetypesIds.Contains(a.Id)).ToList();

            db.Spells.Add(spell);
        }
        db.SaveChanges();

        db.MagicItems.AddRange(DefaultMagicItems);
        db.SaveChanges();
    }
}
