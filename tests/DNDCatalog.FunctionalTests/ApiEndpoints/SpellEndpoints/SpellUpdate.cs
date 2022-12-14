using Ardalis.HttpClientTestExtensions;
using DNDCatalog.Web;
using DNDCatalog.Web.Endpoints.MagicItemEndpoints;
using DNDCatalog.Web.Endpoints.SpellEndpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace DNDCatalog.FunctionalTests.ApiEndpoints.SpellEndpoints;

[Collection("Sequential")]
public class SpellUpdate : IClassFixture<DNDCatalogAPIApplicationFactory<WebMarker>>
{
    private const string Route = "api/v1/spells";

    private readonly HttpClient _client;

    public SpellUpdate(DNDCatalogAPIApplicationFactory<WebMarker> factory)
    {
        _client = factory.CreateClient();
    }


    [Fact]
    public async Task WithoutToken_ReturnsUnauthorized()
    {
        var request = new UpdateSpellRequest() { Id = Guid.NewGuid() };
        var content = new StringContent(JsonSerializer.Serialize(request));

        await _client.PutAndEnsureUnauthorizedAsync("api/v1/spells", content);
    }

    public static IEnumerable<object[]> BadRoleTest
    {
        get
        {
            yield return new object[] { MockJwtToken.GenerateJwtTokenAsBadUser() };
            yield return new object[] { MockJwtToken.GenerateJwtTokenAsAdministrator() };
        }
    }

    [Theory]
    [MemberData(nameof(BadRoleTest))]
    public async Task WithBadRole_ReturnsForbidden(string authToken)
    {
        var request = new UpdateSpellRequest() { Id = Guid.NewGuid() };
        var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authToken}");

        await _client.PutAndEnsureForbiddenAsync(Route, content);
    }

    [Fact]
    public async Task WithNonExistedItemId_UpdatesItem()
    {
        string authToken = MockJwtToken.GenerateJwtTokenAsEditor();

        var request = new UpdateSpellRequest() { Id = Guid.NewGuid() };
        var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authToken}");

        await _client.PutAndEnsureNotFoundAsync(Route, content);
    }

    [Fact]
    public async Task WithExistingSpell_UpdatesSpell()
    {
        string authToken = MockJwtToken.GenerateJwtTokenAsEditor();

        var request = new UpdateSpellRequest()
        {
            Id = FakeData.spellFireball.Id,
            Description = "Updated Description",
            Source = "New Source",
            Classes = new List<Guid> { FakeData.classWizard.Id },
            Archetypes = new List<Guid> { FakeData.archetype1.Id },
        };
        var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authToken}");

        var result = await _client.PutAndDeserializeAsync<UpdateSpellResponse>(Route, content);

        Assert.NotNull(result);
    }

}
