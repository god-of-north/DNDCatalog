using Ardalis.HttpClientTestExtensions;
using DNDCatalog.Web;
using DNDCatalog.Web.Endpoints.ClassEndpoints;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace DNDCatalog.FunctionalTests.ApiEndpoints.ClassEndpoints;


[Collection("Sequential")]
public class ClassList : IClassFixture<DNDCatalogAPIApplicationFactory<WebMarker>>
{
    private readonly HttpClient _client;

    public ClassList(DNDCatalogAPIApplicationFactory<WebMarker> factory)
	{
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task ReturnsAllClasses()
    {
        var result = await _client.GetAndDeserializeAsync<ClassListResponse>("/api/v1/Classes");

        Assert.Equal(FakeData.DefaultClasses.Count(), result.Classes.Count());
        Assert.Contains(result.Classes, c => c.Name == FakeData.classDruid.Name);
    }

}
