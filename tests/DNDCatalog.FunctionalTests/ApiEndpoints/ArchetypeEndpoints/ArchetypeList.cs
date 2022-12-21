using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.HttpClientTestExtensions;
using DNDCatalog.Web;
using DNDCatalog.Web.Endpoints.ArchetypeEndpoints;
using Xunit;

namespace DNDCatalog.FunctionalTests.ApiEndpoints.ArchetypeEndpoints;

[Collection("Sequential")]
public class ArchetypeList : IClassFixture<DNDCatalogAPIApplicationFactory<WebMarker>>
{
    private readonly HttpClient _client;

    public ArchetypeList(DNDCatalogAPIApplicationFactory<WebMarker> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task ReturnsAllArchetypes()
    {
        var result = await _client.GetAndDeserializeAsync<ArchetypeListResponse>("/api/v1/classes/Archetypes");

        Assert.Equal(FakeData.DefaultArchetypes.Count(), result.Archetypes.Count());
        Assert.Contains(result.Archetypes, c => c.Id == FakeData.archetype4.Id);
    }

}
