using System.Net.Http.Headers;
using System.Net.Http.Json;
using App.DTO.v1;
using App.DTO.v1.Identity;
using App.Tests;
using Microsoft.AspNetCore.Mvc.Testing;

namespace App.Test.Integrations.Api;


public class MainFlow : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly CustomWebApplicationFactory<Program> _factory;

    private static readonly Guid TestMiniatureId = Guid.Parse("00000000-0000-0000-0000-000000000001");
    private static readonly Guid TestMiniStateId = Guid.Parse("10000000-0000-0000-0000-000000000001");
    private static readonly Guid TestPersonId = Guid.Parse("11000000-0000-0000-0000-000000000003");

    public MainFlow(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
    }

    private async Task<string> LoginAsync(string email, string password)
    {
        var login = new LoginInfo
        {
            Email = email,
            Password = password
        };

        var response =
            await _client.PostAsJsonAsync(
                "/api/v1.0/Account/Login?jwtExpiresInSeconds=3600&refreshTokenExpiresInSeconds=3600", login);
        response.EnsureSuccessStatusCode();
        var jwt = await response.Content.ReadFromJsonAsync<JWTResponse>();
        return jwt!.JWT;
    }

    [Fact]
    public async Task User_CanCreateMiniature_AndAddToCollection()
    {
        // Login
        var jwt = await LoginAsync("user@taltech.ee", "Foo.Bar.2");
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

        // Create miniature
        var createMiniDto = new MiniatureCollectionCreate()
        {
            CollectionName = "Test Miniature",
            CollectionDesc = "Test Miniature Description",
            AcquisitionDate = DateTime.UtcNow,
            CompletionDate = DateTime.UtcNow.AddDays(5),
            MiniatureId = TestMiniatureId,
            MiniStateId = TestMiniStateId,
            PersonId = TestPersonId
        };

        var createResponse = await _client.PostAsJsonAsync("/api/v1.0/MiniatureCollection", createMiniDto);
        createResponse.EnsureSuccessStatusCode();

        var createResponseData = await createResponse.Content.ReadFromJsonAsync<MiniatureCollection>();
        Assert.NotNull(createResponseData);
        Assert.Equal(createMiniDto.CollectionName, createResponseData!.CollectionName);
    }

    [Fact]
    public async Task User_CanList_MiniatureCollection()
    {
        // Login
        var jwt = await LoginAsync("user@taltech.ee", "Foo.Bar.2");
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

        // Create miniature
        var createMiniDto = new MiniatureCollectionCreate()
        {
            CollectionName = "Test Miniature",
            CollectionDesc = "Test Miniature Description",
            AcquisitionDate = DateTime.UtcNow,
            CompletionDate = DateTime.UtcNow.AddDays(5),
            MiniatureId = TestMiniatureId,
            MiniStateId = TestMiniStateId,
            PersonId = TestPersonId
        };

        var createResponse = await _client.PostAsJsonAsync("/api/v1.0/MiniatureCollection", createMiniDto);
        createResponse.EnsureSuccessStatusCode();

        // Now get the list of collections
        var getResponse = await _client.GetAsync("/api/v1.0/MiniatureCollection");
        getResponse.EnsureSuccessStatusCode();

        var collections = await getResponse.Content.ReadFromJsonAsync<List<MiniatureCollection>>();
        Assert.NotNull(collections);
        Assert.NotEmpty(collections!);

        // Verify our created collection is in the list
        var foundCollection = collections!.FirstOrDefault(c => c.CollectionName == "Test Miniature");
        Assert.NotNull(foundCollection);
        Assert.Equal("Test Miniature Description", foundCollection!.CollectionDesc);
        Assert.Equal(TestMiniatureId, foundCollection.MiniatureId);
        Assert.Equal(TestMiniStateId, foundCollection.MiniStateId);
        Assert.Equal(TestPersonId, foundCollection.PersonId);
    }

    [Fact]
    public async Task User_CanDelete_MiniatureCollection()
    {
        // Login
        var jwt = await LoginAsync("user@taltech.ee", "Foo.Bar.2");
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

        // First create a collection
        var createMiniDto = new MiniatureCollectionCreate()
        {
            CollectionName = "Test Miniature To Delete",
            CollectionDesc = "Test Miniature Description",
            AcquisitionDate = DateTime.UtcNow,
            CompletionDate = DateTime.UtcNow.AddDays(5),
            MiniatureId = TestMiniatureId,
            MiniStateId = TestMiniStateId,
            PersonId = TestPersonId
        };

        var createResponse = await _client.PostAsJsonAsync("/api/v1.0/MiniatureCollection", createMiniDto);
        createResponse.EnsureSuccessStatusCode();

        var createdCollection = await createResponse.Content.ReadFromJsonAsync<MiniatureCollection>();
        Assert.NotNull(createdCollection);

        // Delete the collection
        var deleteResponse = await _client.DeleteAsync($"/api/v1.0/MiniatureCollection/{createdCollection!.Id}");
        deleteResponse.EnsureSuccessStatusCode();

        // Verify the collection is deleted by trying to get it
        var getResponse = await _client.GetAsync($"/api/v1.0/MiniatureCollection/{createdCollection.Id}");
        Assert.Equal(System.Net.HttpStatusCode.NotFound, getResponse.StatusCode);

        // Also verify it's not in the list anymore
        var listResponse = await _client.GetAsync("/api/v1.0/MiniatureCollection");
        listResponse.EnsureSuccessStatusCode();

        var collections = await listResponse.Content.ReadFromJsonAsync<List<MiniatureCollection>>();
        Assert.NotNull(collections);
        Assert.DoesNotContain(collections!, c => c.Id == createdCollection.Id);
    }
    

}