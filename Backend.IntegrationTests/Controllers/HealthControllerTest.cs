using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backend.Controllers;
using Xunit;

namespace Backend.IntegrationTests.Controllers;

public class HealthControllerTest
{
    [Fact]
    public async Task HealthControllerOnSuccessReturns200()
    {
        // Arrange
        var controller = new HealthController();

        // Act
        var result = await Task.FromResult(controller.HealthCheck()) as OkResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
    }
}
