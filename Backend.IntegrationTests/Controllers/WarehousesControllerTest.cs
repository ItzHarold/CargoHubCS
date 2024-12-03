using System.Net;
using FluentAssertions;
using Xunit;

namespace Backend.IntegrationTests.Controllers
{
    public class WarehousesControllerTest
    {
        [Fact]
        public async Task GetAllWarehousesOnSuccessReturns200()
        {
            // Arrange
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-API-KEY", "3f5e8b9c-2d4a-4b6a-8f3e-1a2b3c4d5e6f");
            // Check out options TODO

            // Act
            var result = await client.GetAsync("http://localhost:5031/api/warehouses");

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
