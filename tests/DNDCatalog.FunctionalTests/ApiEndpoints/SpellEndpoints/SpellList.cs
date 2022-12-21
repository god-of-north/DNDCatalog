using Ardalis.HttpClientTestExtensions;
using DNDCatalog.Core.MagicItemAggregate;
using DNDCatalog.Core.SpellAggregate;
using DNDCatalog.Web;
using DNDCatalog.Web.Endpoints.MagicItemEndpoints;
using DNDCatalog.Web.Endpoints.SpellEndpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DNDCatalog.FunctionalTests.ApiEndpoints.SpellEndpoints;


[Collection("Sequential")]
public class SpellList : IClassFixture<DNDCatalogAPIApplicationFactory<WebMarker>>
{
    private readonly HttpClient _client;

    public SpellList(DNDCatalogAPIApplicationFactory<WebMarker> factory)
    {
        _client = factory.CreateClient();
    }

    public int GetSpellCountOnPage(int page)
    {
        int total = FakeData.DefaultSpells.Count();
        int pageSize = SpellConstants.SpellsOnPage;
        int rest = total - (page * pageSize);
        return rest>pageSize?pageSize:rest;
    }


    [Fact]
    public async Task WithoutParameters_ReturnsPageOfItems()
    {
        var result = await _client.GetAndDeserializeAsync<SpellListResponse>("/api/v1/spells");

        Assert.NotEmpty(result.Spells);
        Assert.Equal(GetSpellCountOnPage(0), result.Spells.Count());
        Assert.Equal(FakeData.DefaultSpells.Count(), result.TotalCount);
        Assert.Contains(result.Spells.Select(x => x.Id).First(), FakeData.DefaultSpells.Select(x => x.Id));
    }

    [Fact]
    public async Task WithNonExistingPage_ReturnsEmptyPage()
    {
        var result = await _client.GetAndDeserializeAsync<SpellListResponse>("/api/v1/spells?page=100");

        Assert.Empty(result.Spells);
        Assert.Equal(FakeData.DefaultSpells.Count(), result.TotalCount);
    }


}
