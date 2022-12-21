using Ardalis.HttpClientTestExtensions;
using DNDCatalog.Web;
using DNDCatalog.Web.Endpoints.SpellEndpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DNDCatalog.FunctionalTests.ApiEndpoints.SpellEndpoints;


[Collection("Sequential")]
public class SpellGetById : IClassFixture<DNDCatalogAPIApplicationFactory<WebMarker>>
{
    private readonly HttpClient _client;

    public SpellGetById(DNDCatalogAPIApplicationFactory<WebMarker> factory)
    {
        _client = factory.CreateClient();
    }
    private string BuildRoute(string spellId) => $"/api/v1/Spells/{spellId}";

    public static IEnumerable<object[]> TestDataWithExistingIds
    {
        get
        {
            yield return new object[] { FakeData.spellFireball.Id.ToString(), FakeData.spellFireball.NameEng, 6, 4 };
            yield return new object[] { FakeData.spellDetectMagic.Id.ToString(), FakeData.spellDetectMagic.NameEng, 8, 2 };
            yield return new object[] { FakeData.spellMagicWeapon.Id.ToString(), FakeData.spellMagicWeapon.NameEng, 6, 4 };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataWithExistingIds))]
    public async Task ReturnsSpellByGivenId(string requestedId, string nameEng, int classesCount, int archetypesCount)
    {
        var result = await _client.GetAndDeserializeAsync<GetSpellByIdResponse>(BuildRoute(requestedId));

        Assert.Equal(nameEng, result.Name.Eng);
        Assert.Equal(classesCount, result.Classes.Count);
        Assert.Equal(archetypesCount, result.Archetypes.Count);
    }

    [Fact]
    public async Task ReturnsNotFoundGivenId()
    {
        string route = BuildRoute("notAnId");
        _ = await _client.GetAndEnsureNotFoundAsync(route);
    }


}
