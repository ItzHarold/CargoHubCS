using Backend.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Backend.UnitTests.Controllers;

public class HealthControllerTest
{

    [Fact]
    public void HealthControllerOnSuccessReturns200()
    {
        // Arrange
        var sut = new HealthController();

        // Act
        var result = sut.HealthCheck() as OkResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
    }
}
