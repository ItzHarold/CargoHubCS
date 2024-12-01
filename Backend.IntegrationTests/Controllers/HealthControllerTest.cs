using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

public class HealthControllerTest
{
    private readonly HttpClient _client;

    public HealthControllerTest()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://localhost:5031");
        var apiKey = "3f5e8b9c-2d4a-4b6a-8f3e-1a2b3c4d5e6f";
        _client.DefaultRequestHeaders.Add("X-API-KEY", apiKey);
    }

    [Fact]
    public async Task HealthControllerOnSuccessReturns200()
    {
        var response = await _client.GetAsync("/health");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
