using Ardalis.HttpClientTestExtensions;
using DNDCatalog.Web;
using DNDCatalog.Web.Endpoints.ClassEndpoints;
using DNDCatalog.Web.Endpoints.SourceEndpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DNDCatalog.FunctionalTests.ApiEndpoints.SourceEndpoints;


[Collection("Sequential")]
public class SourceList : IClassFixture<DNDCatalogAPIApplicationFactory<WebMarker>>
{
    private readonly HttpClient _client;

    public SourceList(DNDCatalogAPIApplicationFactory<WebMarker> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task ReturnsAllSources()
    {
        var result = await _client.GetAndDeserializeAsync<SourceListResponse>("/api/v1/Sources");

        var sources = FakeData.DefaultSpells.Select(c=>c.Source).Distinct().ToList();
        Assert.Equal(sources.Count(), result.Sources.Count());
        Assert.Contains(result.Sources, s => s == sources[0]);
    }
}
