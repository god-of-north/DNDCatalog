using Ardalis.HttpClientTestExtensions;
using DNDCatalog.Core.MagicItemAggregate;
using DNDCatalog.Web;
using DNDCatalog.Web.Endpoints.MagicItemEndpoints;
using DNDCatalog.Web.Endpoints.SpellEndpoints;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace DNDCatalog.FunctionalTests.ApiEndpoints.MagicItemEndpoints;


[Collection("Sequential")]
public class MagicItemGetById : IClassFixture<DNDCatalogAPIApplicationFactory<WebMarker>>
{
    private readonly HttpClient _client;

    public MagicItemGetById(DNDCatalogAPIApplicationFactory<WebMarker> factory)
    {
        _client = factory.CreateClient();
    }

    private string BuildRoute(string id) => $"/api/v1/MagicItems/{id}";

    public static IEnumerable<object[]> TestDataWithExistingIds
    {
        get
        {
            yield return new object[] { FakeData.magicItemBookOfVileDarkness};
            yield return new object[] { FakeData.magicItemMaceOfSmiting};
            yield return new object[] { FakeData.magicItemRingOfProtection};
        }
    }

    [Theory]
    [MemberData(nameof(TestDataWithExistingIds))]
    public async Task ReturnsMagicItemByGivenId(MagicItem item)
    {
        var result = await _client.GetAndDeserializeAsync<GetMagicItemByIdResponse>(BuildRoute(item.Id.ToString()));

        Assert.Equal(item.NameEng, result.Name.Eng);
        Assert.Equal(item.Type, result.Type);
        Assert.Equal(item.Rarity, result.Rarity);
    }

    [Fact]
    public async Task ReturnsNotFoundGivenId()
    {
        string route = BuildRoute("notAnId");
        _ = await _client.GetAndEnsureNotFoundAsync(route);
    }

}
