using System.Net;
using System.Net.Http.Json;
using App.DTO.v1.Identity;
using App.Tests;
using Microsoft.AspNetCore.Mvc.Testing;

namespace App.Test.Integrations.Api;

[Collection("Sequential")]
public class IdentityTests: IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly CustomWebApplicationFactory<Program> _factory;

    public IdentityTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
    }
    
    [Fact]
    public async Task Register_New_User()
    {
        // Arrange
        var registrationData = new Register()
        {
            Email = "test@test.ee",
            FirstName = "Test",
            LastName = "User",
            Password = "Password.123"
        };

        // Act
        var response = await _client.PostAsJsonAsync("api/v1/account/register", registrationData);

        // Assert
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<JWTResponse>();
        Assert.NotNull(responseData);
        Assert.True(responseData.JWT.Length > 128);
        Assert.True(responseData.RefreshToken.Length == Guid.NewGuid().ToString().Length);
    }
    
    [Fact]
    public async Task Login_Existing_User()
    {
        // Arrange
        var loginData = new LoginInfo()
        {
            Email = "user@taltech.ee",
            Password = "Foo.Bar.2"
        };

        // Act
        var response = await _client.PostAsJsonAsync("/api/v1/account/login", loginData);

        // Assert
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<JWTResponse>();
        Assert.NotNull(responseData);
        Assert.True(responseData.JWT.Length > 128);
        Assert.True(responseData.RefreshToken.Length == Guid.NewGuid().ToString().Length);
    }

    [Fact]
    public async Task Login_Existing_User_Check_Rights()
    {
        // Arrange
        var loginData = new LoginInfo()
        {
            Email = "user@taltech.ee",
            Password = "Foo.Bar.2"
        };

        // Act
        var response = await _client.PostAsJsonAsync("/api/v1/account/login", loginData);

        // Assert
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<JWTResponse>();
        Assert.NotNull(responseData);
        Assert.True(responseData.JWT.Length > 128);
        Assert.True(responseData.RefreshToken.Length == Guid.NewGuid().ToString().Length);
        
        _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", responseData.JWT);
        
        var getResponse = await _client.GetAsync("/api/v1/person");
        getResponse.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task No_Bearer_Header_Unauthorized()
    {
        var getResponse = await _client.GetAsync("/api/v1/person");
        Assert.Equal(HttpStatusCode.Unauthorized, getResponse.StatusCode);
    }
    
    [Fact]
    public async Task JWT_Custom_Expiration()
    {
        // Arrange
        var loginData = new LoginInfo()
        {
            Email = "user@taltech.ee",
            Password = "Foo.Bar.2"
        };

        // Act
        var response = await _client.PostAsJsonAsync("/api/v1/account/login?jwtExpiresInSeconds=1", loginData);

        // Assert
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<JWTResponse>();
        Assert.NotNull(responseData);
        Assert.True(responseData.JWT.Length > 128);
        Assert.True(responseData.RefreshToken.Length == Guid.NewGuid().ToString().Length);
        
        _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", responseData.JWT);
        
        var getResponse = await _client.GetAsync("/api/v1/person");
        getResponse.EnsureSuccessStatusCode();
        
        // Wait for JWT to expire
        await Task.Delay(1500);
        var getResponseAuthExpired = await _client.GetAsync("/api/v1/person");
        
        Assert.Equal(HttpStatusCode.Unauthorized, getResponseAuthExpired.StatusCode);
    }

    [Fact]
    public async Task JWT_Refresh()
    {
        // Arrange
        var loginData = new LoginInfo()
        {
            Email = "user@taltech.ee",
            Password = "Foo.Bar.2"
        };

        // Act - Set a longer expiration for the refresh token (e.g., 30 seconds)
        var response = await _client.PostAsJsonAsync("/api/v1/account/login?jwtExpiresInSeconds=1&refreshTokenExpiresInSeconds=30", loginData);

        // Assert
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<JWTResponse>();
        Assert.NotNull(responseData);
        Assert.True(responseData.JWT.Length > 128);
        Assert.True(responseData.RefreshToken.Length == Guid.NewGuid().ToString().Length);
        
        _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", responseData.JWT);
        
        var getResponse = await _client.GetAsync("/api/v1/person");
        getResponse.EnsureSuccessStatusCode();
        
        // Wait for JWT to expire
        await Task.Delay(1500);

        var getResponseAuthExpired = await _client.GetAsync("/api/v1/person");
        Assert.Equal(HttpStatusCode.Unauthorized, getResponseAuthExpired.StatusCode);
        
        // Clear the expired JWT from headers before refresh
        _client.DefaultRequestHeaders.Authorization = null;
        
        // Refresh JWT - Use the same refresh token expiration time
        var refreshResponse = await _client.PostAsJsonAsync("/api/v1/account/RenewRefreshToken?refreshTokenExpiresInSeconds=30", new RefreshTokenModel()
        {
            Jwt = responseData.JWT,
            RefreshToken = responseData.RefreshToken
        });
        
        // Add error handling to see what's going wrong
        if (!refreshResponse.IsSuccessStatusCode)
        {
            var errorContent = await refreshResponse.Content.ReadAsStringAsync();
            throw new Exception($"Refresh token failed with status {refreshResponse.StatusCode}. Error: {errorContent}");
        }
        
        var refreshedResponseData = await refreshResponse.Content.ReadFromJsonAsync<JWTResponse>();
        Assert.NotNull(refreshedResponseData);
        
        _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", refreshedResponseData.JWT);
        
        var getResponse2 = await _client.GetAsync("/api/v1/person");
        getResponse2.EnsureSuccessStatusCode();
    }
}