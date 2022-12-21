using Ardalis.HttpClientTestExtensions;
using DNDCatalog.Core.MagicItemAggregate;
using DNDCatalog.Web;
using DNDCatalog.Web.Endpoints.MagicItemEndpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DNDCatalog.FunctionalTests.ApiEndpoints.MagicItemEndpoints;


[Collection("Sequential")]
public class MagicItemList : IClassFixture<DNDCatalogAPIApplicationFactory<WebMarker>>
{
    private readonly HttpClient _client;

    public MagicItemList(DNDCatalogAPIApplicationFactory<WebMarker> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task WithoutParameters_ReturnsPageOfItems()
    {
        var result = await _client.GetAndDeserializeAsync<MagicItemListResponse>("/api/v1/MagicItems");

        Assert.NotEmpty(result.MagicItems);
        Assert.Equal(MagicItemConstants.MagicItemsOnPage, result.MagicItems.Count());
        Assert.Equal(FakeData.DefaultMagicItems.Count(), result.TotalCount);
        Assert.Contains(result.MagicItems.Select(x => x.Id).First(), FakeData.DefaultMagicItems.Select(x=>x.Id));
    }

    [Fact]
    public async Task WithPageNumber_ReturnsRequestedPage()
    {
        var result = await _client.GetAndDeserializeAsync<MagicItemListResponse>("/api/v1/MagicItems?page=1");

        Assert.NotEmpty(result.MagicItems);
        Assert.Equal(FakeData.DefaultMagicItems.Count()-MagicItemConstants.MagicItemsOnPage, result.MagicItems.Count());
        Assert.Equal(FakeData.DefaultMagicItems.Count(), result.TotalCount);
        Assert.Contains(result.MagicItems.Select(x => x.Id).First(), FakeData.DefaultMagicItems.Select(x=>x.Id));
    }

    [Fact]
    public async Task WithNonExistingPage_ReturnsEmptyPage()
    {
        var result = await _client.GetAndDeserializeAsync<MagicItemListResponse>("/api/v1/MagicItems?page=100");

        Assert.Empty(result.MagicItems);
        Assert.Equal(FakeData.DefaultMagicItems.Count(), result.TotalCount);
    }


    public static IEnumerable<object[]> TestFilters
    {
        get
        {
            yield return new object[] { "search=potion", 4, 4, FakeData.magicItemPotionOfFireBreath.Id };
            yield return new object[] { "Rarities=3&Rarities=5", 10, 10, FakeData.magicItemCloakOfInvisibility.Id };
            yield return new object[] { "Types=8&Types=4", 2, 2, FakeData.magicItemWandOfSecrets.Id };
            yield return new object[] { "PriceMin=70&PriceMax=200", 10, 10, FakeData.magicItemAdamantineArmor.Id };
            yield return new object[] { "Sources=Бестиарий", 1, 1, FakeData.magicItemHagEye.Id };
            yield return new object[] { "Attunement=false", 16, 16, FakeData.magicItemPotionOfFireBreath.Id };
            yield return new object[] { "MagicBonuses=3", 1, 1, FakeData.magicItemArmorPlus3.Id };
            yield return new object[] { "Consumable=true", 5, 5, FakeData.magicItemPotionOfClimbing.Id };
            yield return new object[] { "Charged=true", 2, 2, FakeData.magicItemGemOfSeeing.Id };
        }
    }

    [Theory]
    [MemberData(nameof(TestFilters))]
    public async Task WithFilterQuery_ReturnsFiltredItems(string query, int expectedItemsCount, int expectedTotalCount, Guid expectedItemId)
    {
        var result = await _client.GetAndDeserializeAsync<MagicItemListResponse>($"/api/v1/MagicItems?{query}");

        Assert.NotEmpty(result.MagicItems);
        Assert.Equal(expectedItemsCount, result.MagicItems.Count());
        Assert.Equal(expectedTotalCount, result.TotalCount);
        Assert.Contains(expectedItemId, result.MagicItems.Select(x => x.Id));
    }


}
