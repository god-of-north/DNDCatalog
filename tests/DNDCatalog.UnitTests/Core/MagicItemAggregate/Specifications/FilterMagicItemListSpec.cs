using DNDCatalog.Core.MagicItemAggregate;
using DNDCatalog.UnitTests.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace DNDCatalog.UnitTests.Core.MagicItemAggregate.Specifications;

public class FilterMagicItemListSpec
{
    public static IEnumerable<object[]> CorrectTestParams
    {
        get
        {
            yield return new object[] {
                null, //rarities
                null, //magicItemType
                null, //minPrice
                null, //maxPrice
                null, //Sources
                true, //attunement
                null, //magicBonuses
                null, //consumable
                null, //charged
                FakeData.GetMagicItems().Where(x=>x.Attunement).Count(), //expectedCount
                FakeData.GetMagicItems().Where(x=>x.Attunement).Select(x=>x.Id).ToArray() //expectedIds
            };
            yield return new object[] {
                null, //rarities
                null, //magicItemType
                null, //minPrice
                null, //maxPrice
                null, //Sources
                false, //attunement
                null, //magicBonuses
                null, //consumable
                null, //charged
                FakeData.GetMagicItems().Where(x=>!x.Attunement).Count(), //expectedCount
                FakeData.GetMagicItems().Where(x=>!x.Attunement).Select(x=>x.Id).ToArray() //expectedIds
            };

            yield return new object[] {
                null, //rarities
                null, //magicItemType
                null, //minPrice
                null, //maxPrice
                null, //Sources
                null, //attunement
                null, //magicBonuses
                true, //consumable
                null, //charged
                FakeData.GetMagicItems().Where(x=>x.Consumable).Count(), //expectedCount
                FakeData.GetMagicItems().Where(x=>x.Consumable).Select(x=>x.Id).ToArray() //expectedIds
            };
            yield return new object[] {
                null, //rarities
                null, //magicItemType
                null, //minPrice
                null, //maxPrice
                null, //Sources
                null, //attunement
                null, //magicBonuses
                false, //consumable
                null, //charged
                FakeData.GetMagicItems().Where(x=>!x.Consumable).Count(), //expectedCount
                FakeData.GetMagicItems().Where(x=>!x.Consumable).Select(x=>x.Id).ToArray() //expectedIds
            };

            yield return new object[] {
                null, //rarities
                null, //magicItemType
                null, //minPrice
                null, //maxPrice
                null, //Sources
                null, //attunement
                null, //magicBonuses
                null, //consumable
                true, //charged
                FakeData.GetMagicItems().Where(x=>x.Charged).Count(), //expectedCount
                FakeData.GetMagicItems().Where(x=>x.Charged).Select(x=>x.Id).ToArray() //expectedIds
            };
            yield return new object[] {
                null, //rarities
                null, //magicItemType
                null, //minPrice
                null, //maxPrice
                null, //Sources
                null, //attunement
                null, //magicBonuses
                null, //consumable
                false, //charged
                FakeData.GetMagicItems().Where(x=>!x.Charged).Count(), //expectedCount
                FakeData.GetMagicItems().Where(x=>!x.Charged).Select(x=>x.Id).ToArray() //expectedIds
            };


            var rarityCombinations = Enum.GetValues(typeof(Rarity)).Cast<Rarity>().ToList().GetCombinations();
            foreach (var rarities in rarityCombinations)
            {
                yield return new object[]
                {
                    rarities, null, null, null, null, null, null, null, null,
                    FakeData.GetMagicItems().Where(x=>rarities.Contains(x.Rarity)).Count(), //expectedCount
                    FakeData.GetMagicItems().Where(x=>rarities.Contains(x.Rarity)).Select(x=>x.Id).ToArray() //expectedIds
                };
            }

            var itemTypeCombinations = Enum.GetValues(typeof(MagicItemType)).Cast<MagicItemType>().ToList().GetCombinations();
            foreach (var itemTypes in itemTypeCombinations)
            {
                yield return new object[]
                {
                    null, itemTypes, null, null, null, null, null, null, null,
                    FakeData.GetMagicItems().Where(x=>itemTypes.Contains(x.Type)).Count(), //expectedCount
                    FakeData.GetMagicItems().Where(x=>itemTypes.Contains(x.Type)).Select(x=>x.Id).ToArray() //expectedIds
                };
            }

            var sourcesCombinations = FakeData.GetMagicItems().Where(x => x.Source != null).Select(x => x.Source).Distinct().GetCombinations();
            foreach (var sources in sourcesCombinations)
            {
                yield return new object[]
                {
                    null, null, null, null, sources, null, null, null, null,
                    FakeData.GetMagicItems().Where(x=>sources.Contains(x.Source)).Count(), //expectedCount
                    FakeData.GetMagicItems().Where(x=>sources.Contains(x.Source)).Select(x=>x.Id).ToArray() //expectedIds
                };
            }

            var bonusesCombinations = FakeData.GetMagicItems().Where(x => x.MagicBonus != null).Select(x => (int)x.MagicBonus!).Distinct().GetCombinations();
            foreach (var bonuses in bonusesCombinations)
            {
                yield return new object[]
                {
                    null, null, null, null, null, null, bonuses, null, null,
                    FakeData.GetMagicItems().Where(x=>x.MagicBonus!=null && bonuses.Contains((int)x.MagicBonus!)).Count(), //expectedCount
                    FakeData.GetMagicItems().Where(x=>x.MagicBonus!=null && bonuses.Contains((int)x.MagicBonus!)).Select(x=>x.Id).ToArray() //expectedIds
                };
            }

            var rnd = new Random();
            int minPrice = (int)FakeData.GetMagicItems().Where(x => x.Price != null && x.Price.MinPrice != null).Select(x => x.Price!.MinPrice).Min()!;
            int maxPrice = (int)FakeData.GetMagicItems().Where(x => x.Price != null && x.Price.MaxPrice != null).Select(x => x.Price!.MaxPrice).Max()!;
            for (int i = 0; i < 10; i++)
            {
                var price = rnd.Next(0, maxPrice);
                yield return new object[]
                {
                    null, null, price, null, null, null, null, null, null,
                    FakeData.GetMagicItems().Where(x=>x.Price!=null && x.Price.MaxPrice!=null && x.Price.MaxPrice>=price).Count(), //expectedCount
                    FakeData.GetMagicItems().Where(x=>x.Price!=null && x.Price.MaxPrice!=null && x.Price.MaxPrice>=price).Select(x=>x.Id).ToArray() //expectedIds
                };

                price = rnd.Next(minPrice, maxPrice + 100);
                yield return new object[]
                {
                    null, null, null, price, null, null, null, null, null,
                    FakeData.GetMagicItems().Where(x=>x.Price!=null && x.Price.MinPrice!=null && x.Price.MinPrice<=price).Count(), //expectedCount
                    FakeData.GetMagicItems().Where(x=>x.Price!=null && x.Price.MinPrice!=null && x.Price.MinPrice<=price).Select(x=>x.Id).ToArray() //expectedIds
                };

                var priceMin = rnd.Next(minPrice, maxPrice);
                var priceMax = rnd.Next(priceMin, maxPrice + 100);
                yield return new object[]
                {
                    null, null, priceMin, priceMax, null, null, null, null, null,
                    FakeData.GetMagicItems().Where(x=>x.Price!=null && x.Price.MinPrice!=null && x.Price.MinPrice<=priceMax)
                                            .Where(x=>x.Price!=null && x.Price.MaxPrice!=null && x.Price.MaxPrice>=priceMin).Count(), //expectedCount
                    FakeData.GetMagicItems().Where(x=>x.Price!=null && x.Price.MinPrice!=null && x.Price.MinPrice<=priceMax)
                                            .Where(x=>x.Price!=null && x.Price.MaxPrice!=null && x.Price.MaxPrice>=priceMin).Select(x=>x.Id).ToArray() //expectedIds
                };

            }


        }
    }

    [Theory]
    [MemberData(nameof(CorrectTestParams))] 
    public void FilterMagicItems_WithCorrectParams_ReturnsExpectedItems(
        Rarity[]? rarities,
        MagicItemType[]? types,
        int? priceMin,
        int? priceMax,
        string[]? sources,
        bool? attunement,
        int[]? magicBonuses,
        bool? consumable,
        bool? charged,
        int expectedCount,
        Guid[] expectedIds)
    {
        //Arrange
        var spec = new DNDCatalog.Core.MagicItemAggregate.Specifications.FilterMagicItemListSpec(rarities,types,priceMin,priceMax,sources,attunement,magicBonuses,consumable,charged);

        //Act
        var result = spec.Evaluate(FakeData.GetMagicItems()).ToList();

        //Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Equal(expectedCount, result.Count());
        Assert.Equal(expectedCount, result.Select(c => c.Id).Intersect(expectedIds).Count());
    }

}
