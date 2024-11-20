using System;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Backend.IntegrationTests.Controllers;

public class HealthControllerTest
{
    readonly HttpClient _httpClient;
    public HealthControllerTest()
    {
        _httpClient = new HttpClient();
    }

    [Fact]
    public async Task HealthControllerOnSuccessReturns200()
    {
        // X-API-KEY: 3f5e8b9c-2d4a-4b6a-8f3e-1a2b3c4d5e6f
        _httpClient.BaseAddress = new Uri("http://localhost:5031/api/");
        _httpClient.DefaultRequestHeaders.Add("X-API-KEY", "3f5e8b9c-2d4a-4b6a-8f3e-1a2b3c4d5e6f");

        var response = await _httpClient.GetAsync("health/");

        response.EnsureSuccessStatusCode();
    }
}
