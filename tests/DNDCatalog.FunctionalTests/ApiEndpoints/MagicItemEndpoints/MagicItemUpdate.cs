using Ardalis.HttpClientTestExtensions;
using DNDCatalog.Web;
using DNDCatalog.Web.Endpoints.MagicItemEndpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace DNDCatalog.FunctionalTests.ApiEndpoints.MagicItemEndpoints;


[Collection("Sequential")]
public class MagicItemUpdate : IClassFixture<DNDCatalogAPIApplicationFactory<WebMarker>>
{
    private const string Route = "api/v1/MagicItems";

    private readonly HttpClient _client;

    public MagicItemUpdate(DNDCatalogAPIApplicationFactory<WebMarker> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task WithoutToken_ReturnsUnauthorized()
    {
        UpdateMagicItemRequest request = new UpdateMagicItemRequest() { Id = Guid.NewGuid() };
        HttpContent content = new StringContent(JsonSerializer.Serialize(request));

        await _client.PutAndEnsureUnauthorizedAsync(Route, content);
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
        UpdateMagicItemRequest request = new UpdateMagicItemRequest() {Id = Guid.NewGuid()};
        HttpContent content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authToken}");

        await _client.PutAndEnsureForbiddenAsync(Route, content);
    }

    [Fact]
    public async Task WithNonExistedItemId_UpdatesItem()
    {
        string authToken = MockJwtToken.GenerateJwtTokenAsEditor();

        UpdateMagicItemRequest request = new UpdateMagicItemRequest() { Id = Guid.NewGuid()};
        HttpContent content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authToken}");

        await _client.PutAndEnsureNotFoundAsync(Route, content);
    }

    [Fact]
    public async Task WithExistingItem_UpdatesItem()
    {
        string authToken = MockJwtToken.GenerateJwtTokenAsEditor();

        UpdateMagicItemRequest request = new UpdateMagicItemRequest()
        { 
            Id = FakeData.magicItemDwarvenPlate.Id,
            Description = "Updated Description"
        };
        HttpContent content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authToken}");

        var result = await _client.PutAndDeserializeAsync<UpdateMagicItemResponse>(Route, content);

        Assert.NotNull(result);
    }
}
